
using ApplicationLayer.NonGenericInterface;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using persistence.APPDBCONTEXT;

namespace VEZEETA.Infrastructure.persistence.Repositories
{
    public class DiscountCodeCouponRepository : GenericRepository<DiscountCodeCoupon>, IDiscountCodeCouponRepository
    {
        private DbSet<DiscountCodeCoupon> _DiscountCodeCoupons;

        public DiscountCodeCouponRepository(AppDbContext context) : base(context)
        {
            _DiscountCodeCoupons = context.Set<DiscountCodeCoupon>();
        }

    }
}
