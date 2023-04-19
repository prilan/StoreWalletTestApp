using SaveState;
using System;
using System.Collections.Generic;

namespace SaveSystem
{
    public interface ISaveSystem
    {
        void SaveDataState(SaveDataState saveData);
        SaveDataState LoadDataState();
        bool HasSaveDataState();
    }
}
