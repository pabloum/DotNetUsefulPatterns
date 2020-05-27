BEGIN TRAN T1
BEGIN TRY
  COMMIT TRAN T1
END TRY
	BEGIN CATCH

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT
			@ErrorMessage = CONCAT(ERROR_MESSAGE(),ERROR_PROCEDURE(),ERROR_LINE()),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		RAISERROR ( @ErrorMessage,
					@ErrorSeverity,
					@ErrorState
					);

		ROLLBACK TRAN T1
	END CATCH
