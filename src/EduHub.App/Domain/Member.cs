namespace EduHub.App.Domain;

public class Member
{
    private bool dangHoatDong = true;
    public Guid Id { get; private set; }
    public string Name { get; private set; } = "";
    public string Email { get; private set; } = "";
    public string StudentCode { get; private set; } = "";
    public DateTime JoinedAt { get; private set; }
    private Member() { }

    public static Member Create(string ten, string email, string maSinhVien)
    {
        if (string.IsNullOrWhiteSpace(ten))
        {
            throw new ArgumentException("Ten khong duoc de trong");
        }
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new ArgumentException("Email khong hop le");
        }
        if (string.IsNullOrWhiteSpace(maSinhVien))
        {
            throw new ArgumentException("Ma sinh vien khong duoc de trong");
        }

        Member thanhVien = new Member();
        thanhVien.Id = Guid.NewGuid();
        thanhVien.Name = ten.Trim();
        thanhVien.Email = email.Trim();
        thanhVien.StudentCode = maSinhVien.Trim();
        thanhVien.JoinedAt = DateTime.Now;
        return thanhVien;
    }

    public bool IsActive()
    {
        return dangHoatDong;
    }

    public void Deactivate()
    {
        dangHoatDong = false;
    }
}