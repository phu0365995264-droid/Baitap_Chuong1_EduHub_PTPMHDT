# User Stories - EduHub

Các tác nhân (Actor): Sinh viên, Ban CLB, Admin

## 1. Tác nhân: Sinh viên

### US1 - Đăng ký tham gia CLB
Là một Sinh viên, tôi muốn đăng ký tham gia một CLB, để trở thành thành viên của CLB.
- Cho sinh viên chưa là thành viên, khi gửi đăng ký vào CLB, thì yêu cầu được tạo với trạng thái "Chờ duyệt".
- Cho sinh viên đã đăng ký CLB đó, khi đăng ký lại, thì hệ thống từ chối và báo lỗi trùng.

### US2 - Đăng ký sự kiện
Là một Sinh viên, tôi muốn đăng ký tham gia sự kiện của CLB, để giữ chỗ và tham dự.
- Cho sự kiện còn chỗ, khi sinh viên đăng ký, thì đăng ký thành công.
- Cho sự kiện đã đủ sức chứa hoặc sinh viên đã đăng ký rồi, khi đăng ký, thì hệ thống từ chối và báo lỗi.

### US3 - Check-in sự kiện
Là một Sinh viên, tôi muốn check-in khi đến sự kiện, để được ghi nhận có mặt.
- Cho sinh viên đã đăng ký sự kiện, khi check-in, thì hệ thống ghi nhận thời gian có mặt.
- Cho sinh viên đã check-in rồi hoặc chưa đăng ký, khi check-in, thì hệ thống từ chối.

## 2. Tác nhân: Ban CLB

### US4 - Tạo sự kiện
Là một Ban CLB, tôi muốn tạo sự kiện cho CLB, để tổ chức hoạt động và mở đăng ký.
- Cho tiêu đề không rỗng, sức chứa lớn hơn 0 và thời gian ở tương lai, khi tạo sự kiện, thì sự kiện được tạo thành công.
- Cho dữ liệu không hợp lệ, khi tạo sự kiện, thì hệ thống báo lỗi và không tạo.

### US5 - Xem danh sách thành viên
Là một Ban CLB, tôi muốn xem danh sách thành viên của CLB, để quản lý và liên hệ khi cần.
- Cho CLB có thành viên đã duyệt, khi xem danh sách, thì hiển thị họ tên và email của từng thành viên.
- Cho thành viên đang chờ duyệt, khi xem danh sách, thì không hiển thị trong danh sách thành viên chính thức.

### US6 - Xuất báo cáo tham dự
Là một Ban CLB, tôi muốn xuất báo cáo tham dự sự kiện, để đánh giá hiệu quả sự kiện.
- Cho sự kiện có đăng ký và check-in, khi xuất báo cáo, thì báo cáo có số đăng ký và số có mặt.
- Cho báo cáo được xuất, khi xem, thì có tỉ lệ tham dự (%) và danh sách có mặt/vắng.

## 3. Tác nhân: Admin

### US7 - Quản lý CLB
Là một Admin, tôi muốn tạo và quản lý thông tin CLB, để duy trì danh sách CLB của hệ thống.
- Cho tên CLB không rỗng, khi tạo CLB, thì CLB được thêm vào hệ thống.
- Cho tên CLB rỗng, khi tạo CLB, thì hệ thống báo lỗi.

### US8 - Phê duyệt thành viên
Là một Admin, tôi muốn phê duyệt yêu cầu tham gia CLB của sinh viên, để kiểm soát thành viên chính thức.
- Cho yêu cầu ở trạng thái "Chờ duyệt", khi Admin phê duyệt, thì sinh viên trở thành thành viên của CLB.
- Cho yêu cầu đã được xử lý, khi duyệt lại, thì hệ thống từ chối.