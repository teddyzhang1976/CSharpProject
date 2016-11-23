use db_TomeTwo
BEGIN Try
    SELECT 1/0;
END Try
BEGIN catch
    SELECT
        ERROR_NUMBER() AS ErrorNumber,--返回错误号
        ERROR_SEVERITY() AS ErrorSeverity,--返回严重性
        ERROR_STATE() AS ErrorState,--返回错误状态号
        ERROR_LINE() AS ErrorLine,--返回导致错误的例程中的行号
        ERROR_MESSAGE() AS ErrorMessage;--返回错误消息的完整文本
END catch;
GO
