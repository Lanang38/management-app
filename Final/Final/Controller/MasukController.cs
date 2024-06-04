using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Final.Model.Entity;
using Final.Model.Repository;
using Final.Model.Context;
using System.Data.SQLite;

namespace Final.Controller
{
    public class MasukController
    {
        private MasukRepository _masukRepository;

        public MasukController(MasukRepository masukRepository)
        {
            _masukRepository = masukRepository;
        }

        public void CreateMasuk(string username, string password)
        {
            Masuk login = new Masuk
            {
                Username = username,
                Password = password
            };

            _masukRepository.Create(login);
        }

        public List<Masuk> GetAllMasuk()
        {
            return _masukRepository.ReadAll();
        }

        public void UpdateMasuk(string username, string newPassword)
        {
            Masuk login = new Masuk
            {
                Username = username,
                Password = newPassword
            };

            _masukRepository.Update(login);
        }

        public void DeleteMasuk(string username)
        {
            _masukRepository.Delete(username);
        }
    }
}
