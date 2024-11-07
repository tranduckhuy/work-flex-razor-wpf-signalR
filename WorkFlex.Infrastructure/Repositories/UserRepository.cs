using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorkFlex.Domain;
using WorkFlex.Domain.Entities;
using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Constants;
using WorkFlex.Infrastructure.Data;

namespace WorkFlex.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _appDbContext.Users
                .Include(r => r.Role)
                .Include(p => p.Profile)
                .Include(j => j.JobPosts)
                .Include(ja => ja.JobApplications)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _appDbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> IsAccountLockedAsync(string email)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return user.IsLock;
        }

        public async Task<(ICollection<User>, Pageable<SearchCriteria>)> GetUsers(int page,
            SearchCriteria? searchCriteria, int roleId = AppConstants.ALL_ROLE, Expression<Func<User, bool>> additionalCriteria = null!)
        {
            const int pageSize = 6;

            IQueryable<User> query = _appDbContext.Users;

            if (roleId != AppConstants.ALL_ROLE)
            {
                query = query.Where(u => u.RoleId == roleId);
            }

            if (additionalCriteria != null)
            {
                query = query.Where(additionalCriteria);
            }

            if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.SearchValue))
            {
                string searchValue = searchCriteria.SearchValue.ToLower().Trim();
                switch (searchCriteria.SearchOption)
                {
                    case nameof(AppConstants.UserSearchOption.Name):
                        query = query.Where(u =>
                            EF.Functions.Like(
                                EF.Functions.Collate((u.FirstName + " " + u.LastName), "Latin1_General_CI_AI"),
                                $"%{searchValue}%"
                            )
                        );
                        break;

                    case nameof(AppConstants.UserSearchOption.Email):
                        query = query.Where(u => u.Email.ToLower().Contains(searchValue));
                        break;

                    default:
                        break;
                }
            }

            int totalUsers = await query.CountAsync();

            var pageable = new Pageable<SearchCriteria>(totalUsers, page, pageSize)
            {
                SearchCriteria = searchCriteria
            };

            int skipAmount = (pageable.CurrentPage - 1) * pageSize;
            var users = await query.Skip(skipAmount).Take(pageSize).Include(u => u.Role).ToListAsync();

            return (users, pageable);
        }

        public async Task LockUnlockUser(Guid userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId) ?? throw new Exception("User not found.");

            user.IsLock = !user.IsLock;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> DemotePromoteUser(Guid userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId) ?? throw new Exception("User not found.");

            if (AppConstants.Role.Admin.Equals(user.RoleId))
            {
                throw new Exception("Cannot demote/promote admin.");
            }

            user.RoleId = (int)AppConstants.Role.Recruiter == user.RoleId ?
                (int)AppConstants.Role.JobSeeker :
                (int)AppConstants.Role.Recruiter;
            user.IsRecruiterRequestPending = false;

            await _appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task AddUserAsync(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> RequestRecruiterApproval(Guid userId)
        {
            var user = await GetUserByIdAsync(userId) ?? throw new Exception("User not found.");

            if (!IsProfileComplete(user))
            {
                return false;
            }

            if (AppConstants.Role.Recruiter.Equals(user.RoleId))
            {
                throw new Exception("User is already a recruiter!");
            }

            user.IsRecruiterRequestPending = true;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        private static bool IsProfileComplete(User user)
        {
            return !string.IsNullOrEmpty(user.Profile.Headline) &&
                   !string.IsNullOrEmpty(user.Profile.Summary) &&
                   !string.IsNullOrEmpty(user.Phone) &&
                   !string.IsNullOrEmpty(user.Location);
        }

        public async Task<User> DeclineRecruiterRequest(Guid userId)
        {
            var user = await GetUserByIdAsync(userId) ?? throw new Exception("User not found.");

            user.IsRecruiterRequestPending = false;

            await _appDbContext.SaveChangesAsync();
            return user;
        }
    }
}
