using LivePlay.Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Server.Core.Interfaces;

public interface ICouponRepository
{
    public Task<Coupon[]> GetAll();
    public Task<Coupon> GetById(int id);
    public Task<Coupon> GetByIdAndUserId(int id, Guid userId);
    public void Create(Coupon coupon);
    public void LinkedUser(int couponId, Guid userId);
}
