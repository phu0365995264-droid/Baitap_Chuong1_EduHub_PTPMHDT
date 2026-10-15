namespace EduHub.App.Domain;
public class Event
{
    public Guid Id { get; private set; }
    public Guid ClubId { get; private set; }
    public string Title { get; private set; } = "";
    public DateTime Date { get; private set; }
    public int Capacity { get; private set; }
    public bool IsOnline { get; private set; }
    private Event() { }

    public static Event Create(Guid maClub, string tieuDe, DateTime ngay, int sucChua, bool laOnline)
    {
        if (maClub == Guid.Empty)
        {
            throw new ArgumentException("Ma CLB khong hop le");
        }
        if (string.IsNullOrWhiteSpace(tieuDe))
        {
            throw new ArgumentException("Tieu de khong duoc de trong");
        }
        if (sucChua <= 0)
        {
            throw new ArgumentException("Suc chua phai lon hon 0");
        }

        Event suKien = new Event();
        suKien.Id = Guid.NewGuid();
        suKien.ClubId = maClub;
        suKien.Title = tieuDe.Trim();
        suKien.Date = ngay;
        suKien.Capacity = sucChua;
        suKien.IsOnline = laOnline;
        return suKien;
    }

    public bool HasCapacity(int soDaDangKy)
    {
        return soDaDangKy < Capacity;
    }
}