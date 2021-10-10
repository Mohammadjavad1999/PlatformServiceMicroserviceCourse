namespace PlatformService.Data
{
    public interface IPlatformRep
    {
        bool SaveChange();
        System.Collections.Generic.IEnumerable<PlatformService.Models.Platform> GetAll();
        PlatformService.Models.Platform GetPlatformById(int id);
        void CreatePlatform(PlatformService.Models.Platform plat);

    }
}