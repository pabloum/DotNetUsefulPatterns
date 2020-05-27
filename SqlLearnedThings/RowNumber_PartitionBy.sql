-- Temp TABLE {TABLE_TMP} including pending records from {TABLE_Raw} (IsProcessed = 0)
-- for which there are no pending related records in RequestProcessDetail_{TABLE} (No record should exists where IsProcessed = 0)
-- Pay attention to OVER(PARTITION BY)

SELECT * INTO #MyTable_tmp
FROM
(
  SELECT OGT.*, ROW_NUMBER() OVER(PARTITION BY OGT.PersonID ORDER BY OGT.UpdateDate ASC, OGT.RawID ASC) AS IdInstance
  FROM MyTable_Raw OGT WITH(NOLOCK)
    JOIN Person P on OGT.PersonID = P.PersonID
    LEFT JOIN ProcessDetail_MyTable PD ON OGT.PersonID = PD.PersonID AND PD.IsProcessed = 0
  WHERE OGT.IsProcessed = 0 AND PD.PersonID IS NULL
) OGT WHERE OGT.IdInstance = 1
ORDER BY PersonID
