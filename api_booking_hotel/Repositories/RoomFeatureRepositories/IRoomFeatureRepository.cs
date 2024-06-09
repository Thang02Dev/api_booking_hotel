namespace api_booking_hotel.Repositories.RoomFeatureRepositories
{
    public interface IRoomFeatureRepository
    {
        Task<bool> Create(int roomId, int[] featureId);
        Task<bool> Delete(int id);
    }
}
