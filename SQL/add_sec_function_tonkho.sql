-- =============================================================
-- Thêm quyền menu "Tồn Kho" vào hệ thống phân quyền
-- Chạy 1 lần sau khi deploy bbiTonKho
-- =============================================================

SET NOCOUNT ON;

-- ── 1. Xem cấu trúc SEC_Function hiện tại để tham khảo ───────
SELECT FunctionID, FunctionName, MenuName, FunctionType, ParentID
FROM SEC_Function
WHERE MenuName IN ('bsiManage','bbiPhieuTron','bbiSchedule','bbiContract')
ORDER BY FunctionID;

-- ── 2. Thêm SEC_Function cho bbiTonKho ───────────────────────
DECLARE @ParentID INT;

-- Lấy ParentID của nhóm "Quản Lý" (bsiManage)
SELECT @ParentID = FunctionID
FROM SEC_Function
WHERE MenuName = 'bsiManage';

IF @ParentID IS NULL
BEGIN
    PRINT 'Không tìm thấy bsiManage trong SEC_Function.';
    PRINT 'Kiểm tra lại tên MenuName bằng query ở trên.';
    RETURN;
END

-- Kiểm tra đã tồn tại chưa
IF EXISTS (SELECT 1 FROM SEC_Function WHERE MenuName = 'bbiTonKho')
BEGIN
    PRINT 'bbiTonKho đã có trong SEC_Function — bỏ qua.';
END
ELSE
BEGIN
    INSERT INTO SEC_Function (FunctionName, MenuName, FunctionType, ParentID, Visible)
    VALUES (N'Tồn Kho', 'bbiTonKho', 1, @ParentID, 1);

    PRINT 'Đã thêm SEC_Function: bbiTonKho (FunctionID = ' + CAST(SCOPE_IDENTITY() AS VARCHAR(10)) + ')';
END

-- ── 3. Gán quyền cho TẤT CẢ Role hiện có ────────────────────
-- (Hoặc chỉ role cụ thể — xem danh sách role bên dưới trước)

DECLARE @NewFuncID INT;
SELECT @NewFuncID = FunctionID FROM SEC_Function WHERE MenuName = 'bbiTonKho';

-- Xem danh sách Role để chọn:
SELECT RoleID, RoleName FROM SEC_Role ORDER BY RoleID;

-- Gán cho tất cả Role chưa có quyền này:
INSERT INTO SEC_RoleFunction (RoleID, FunctionID)
SELECT r.RoleID, @NewFuncID
FROM SEC_Role r
WHERE NOT EXISTS (
    SELECT 1 FROM SEC_RoleFunction rf
    WHERE rf.RoleID = r.RoleID AND rf.FunctionID = @NewFuncID
  );

PRINT 'Đã gán quyền bbiTonKho cho ' + CAST(@@ROWCOUNT AS VARCHAR(5)) + ' Role.';

-- ── 4. Kiểm tra kết quả ───────────────────────────────────────
SELECT
    f.FunctionID,
    f.FunctionName,
    f.MenuName,
    r.RoleName
FROM SEC_Function f
JOIN SEC_RoleFunction rf ON rf.FunctionID = f.FunctionID
JOIN SEC_Role         r  ON r.RoleID      = rf.RoleID
WHERE f.MenuName = 'bbiTonKho'
ORDER BY r.RoleName;
