﻿namespace WeaponAccountingProject.ViewModels
{
    public class EditWeaponViewModel
    {
        public int WeaponId { get; set; }
        public string Name { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string? RecordNumber { get; set; } = null!;
        public decimal Value { get; set; } = 0;
        public int? LocationId { get; set; }
    }
}
