namespace P02._Identity_Before.Contracts
{
    using System.Collections.Generic;

    public interface IPasswordChanger
    {

        void ChangePassword(string oldPass, string newPass);

    }
}
