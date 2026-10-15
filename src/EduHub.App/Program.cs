using EduHub.App.Domain;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Registration> danhSachDangKy = new List<Registration>();
List<CheckIn> danhSachCheckIn = new List<CheckIn>();

// ===== 1. TAO CLB VA THANH VIEN =====
Console.WriteLine("===== 1. TAO CLB VA THANH VIEN =====");
Club clb = Club.Create("CLB Lap Trinh", "Sinh hoat cong nghe moi tuan");
Member tv1 = Member.Create("Tran Minh Phu", "phu@gmail.com", "SV001");
Member tv2 = Member.Create("Nguyen Van An", "an@gmail.com", "SV002");
Member tv3 = Member.Create("Le Thi Binh", "binh@gmail.com", "SV003");
Member tv4 = Member.Create("Pham Van Cuong", "cuong@gmail.com", "SV004");
clb.AddMember(tv1);
clb.AddMember(tv2);
clb.AddMember(tv3);
clb.AddMember(tv4);
Console.WriteLine(clb.Name + " co " + clb.MemberCount() + " thanh vien");

// Thu them trung thanh vien -> bao loi
try
{
    clb.AddMember(tv1);
}
catch (InvalidOperationException loi)
{
    Console.WriteLine("Loi: " + loi.Message);
}

// Thu tao thanh vien du lieu sai -> bao loi
try
{
    Member.Create("", "abc", "");
}
catch (ArgumentException loi)
{
    Console.WriteLine("Loi: " + loi.Message);
}

// ===== 2. TAO SU KIEN =====
Console.WriteLine("\n===== 2. TAO SU KIEN =====");
Event suKien = Event.Create(clb.Id, "Workshop Git", DateTime.Now.AddDays(7), 3, false);
Console.WriteLine("Da tao su kien: " + suKien.Title + " (suc chua " + suKien.Capacity + ")");

// ===== 3. DANG KY SU KIEN =====
Console.WriteLine("\n===== 3. DANG KY SU KIEN =====");
Member[] danhSachMuonDangKy = { tv1, tv2, tv3, tv1, tv4 };

foreach (Member tv in danhSachMuonDangKy)
{
    bool daDangKy = false;
    int soDaDangKy = 0;

    foreach (Registration dk in danhSachDangKy)
    {
        if (dk.Status != RegistrationStatus.Cancelled)
        {
            soDaDangKy++;
            if (dk.MemberId == tv.Id)
            {
                daDangKy = true;
            }
        }
    }

    if (daDangKy)
    {
        Console.WriteLine(tv.Name + ": da dang ky roi, khong dang ky trung");
    }
    else if (!suKien.HasCapacity(soDaDangKy))
    {
        Console.WriteLine(tv.Name + ": su kien da het cho");
    }
    else
    {
        Registration phieu = Registration.Create(tv.Id, suKien.Id);
        phieu.Confirm();
        danhSachDangKy.Add(phieu);
        Console.WriteLine(tv.Name + ": dang ky thanh cong (" + phieu.Status + ")");
    }
}

// ===== 4. HUY DANG KY =====
Console.WriteLine("\n===== 4. HUY DANG KY =====");
foreach (Registration dk in danhSachDangKy)
{
    if (dk.MemberId == tv3.Id)
    {
        dk.Cancel();
        Console.WriteLine(tv3.Name + " da huy dang ky (" + dk.Status + ")");
    }
}

// ===== 5. CHECK-IN =====
Console.WriteLine("\n===== 5. CHECK-IN =====");
Member[] danhSachCheckInThu = { tv1, tv1, tv3 };

foreach (Member tv in danhSachCheckInThu)
{
    Registration? phieuTimThay = null;
    foreach (Registration dk in danhSachDangKy)
    {
        if (dk.MemberId == tv.Id)
        {
            phieuTimThay = dk;
        }
    }

    if (phieuTimThay == null || phieuTimThay.Status != RegistrationStatus.Confirmed)
    {
        Console.WriteLine(tv.Name + ": khong co dang ky hop le, khong check-in duoc");
        continue;
    }

    bool daCheckIn = false;
    foreach (CheckIn ci in danhSachCheckIn)
    {
        if (ci.RegistrationId == phieuTimThay.Id)
        {
            daCheckIn = true;
        }
    }

    if (daCheckIn)
    {
        Console.WriteLine(tv.Name + ": da check-in roi");
    }
    else
    {
        CheckIn checkIn = CheckIn.Create(phieuTimThay.Id, CheckInMethod.QR);
        danhSachCheckIn.Add(checkIn);
        Console.WriteLine(tv.Name + ": " + checkIn.Summary());
    }
}

