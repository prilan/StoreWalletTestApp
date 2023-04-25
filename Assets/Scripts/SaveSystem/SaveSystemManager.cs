using System;

namespace SaveSystem
{
    public class SaveSystemManager
    {
        ISaveSystem saveSystem;
        public ISaveSystem SaveSystem => saveSystem;
        
        public SaveSystemManager(ISaveSystem saveSystem)
        {
            this.saveSystem = saveSystem;
        }
    }
}
