﻿namespace guru.Model
{
    public class GuruItem
    {
        private GuruContext context;
        public int id_guru { get; set; }
        public string rfid { get; set; }
        public string nip { get; set; }
        public string nama_guru { get; set; }
        public string alamat { get; set; }
        public int status { get; set; }
   
    }
}
