SET DATEFORMAT mdy
GO
DECLARE @datevar datetime
SET @datevar = '12/31/98'
SELECT @datevar
GO
SET DATEFORMAT ymd
GO
DECLARE @datevar datetime
SET @datevar = '98/12/31'
SELECT @datevar
GO