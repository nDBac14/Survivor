public interface IPoolable
{
    void OnSpawn();    // gọi khi object được lấy ra dùng -> reset trạng thái
    void OnDespawn();  // gọi khi object bị trả về kho -> dọn dẹp
}