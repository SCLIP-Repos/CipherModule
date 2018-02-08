using System;
namespace CipherModule.Interfaces
{
    public interface Out
    {
        string Print();
        void SetPrint(string value);
        

        string Err();
        void SetErr(string value);
    }
}
