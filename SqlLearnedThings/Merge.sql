
MERGE INTO JobCoordinatorsEvent WITH (HOLDLOCK) AS t
USING #JobCoordinatorsEvent_tmp AS dt ON t.JobID = dt.JobID

WHEN MATCHED AND dt.LastUpdate > t.LastUpdate
THEN
    UPDATE SET JobID = dt.JobID
WHEN NOT MATCHED BY TARGET
THEN
  INSERT(JobID) VALUES (dt.JobID)
WHEN NOT MATCHED BY SOURCE
THEN
  DELETE;



-----------------------------
-----------------------------
-----------------------------
UPDATE [dbo].[MyTable_Raw]
	SET  [IsProcessed] = 1
		,[LastProcessedDate] = GetUTCDate()
FROM MyTable_Raw u
INNER JOIN #MyTable_tmp t
ON u.ID = t.ID AND u.LastUpdate = t.LastUpdate AND u.RawID = t.RawID;
