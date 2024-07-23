
using AutoMapper;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;
using Microsoft.EntityFrameworkCore;

namespace LivePlay.Server.Persistence.Repositories;

public class CouponRepository(LivePlayDbContext dbContext, IMapper mapper) : ICouponRepository
{
    private readonly LivePlayDbContext _dbContext = dbContext;
    private readonly UserRepository _userRepository = new(dbContext, mapper);
    private readonly IMapper _mapper = mapper;

    public async Task<Coupon[]> GetAll()
    {
        var allCouponEntities = await _dbContext.Coupons.ToArrayAsync();
        var allCoupons = _mapper.Map<Coupon[]>(allCouponEntities);
        return allCoupons;
    }

    public async Task<Coupon> GetById(int id)
    {
        var couponEntity = await _dbContext.Coupons.FindAsync(id);
        var coupon = _mapper.Map<Coupon>(couponEntity);
        return coupon;
    }

    public async Task<Coupon> GetByIdAndUserId(int id, Guid userId)
    {
        var couponEntity = await _dbContext.Quests.FirstOrDefaultAsync(c => c.Id == id && c.Users.FirstOrDefault(u => u.Id == userId) != null);
        var coupon = _mapper.Map<Coupon>(couponEntity);
        return coupon;
    }

    public async void Create(Coupon coupon)
    {
        var couponEntity = _mapper.Map<CouponEntityModel>(coupon);
        _dbContext.Coupons.Add(couponEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async void LinkedUser(int couponId, Guid userId)
    {
        var userEntity = await _userRepository.GetEntryById(userId);
        var couponEntity = _dbContext.Coupons.FirstOrDefault(c => c.Id == couponId)
            ?? throw new RequestException(ErrorCode.DbGetError, $"Coudn`t fined coupon by id {couponId}");
        couponEntity.Users.Add(userEntity);
        await _dbContext.SaveChangesAsync();
    }
}
