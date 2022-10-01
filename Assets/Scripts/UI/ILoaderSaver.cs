
namespace Game
{
    public interface ILoaderSaver
    {
        public void GetVolume(out float musicVolume, out float sfxVolume);
        public void SetVolume(float music, float sfx);
    }
}
