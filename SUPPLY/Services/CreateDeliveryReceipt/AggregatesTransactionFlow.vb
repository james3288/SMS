Public Class AggregatesTransactionFlow
    Public Function requestorLabel(requestor As String)
        Return $"REQUESTOR: {requestor}"
    End Function

    Public Function transactionLabel(typeOfPurchasing As String, wsRrNo As String)
        Return $"{typeOfPurchasing} ({wsRrNo})"
    End Function

    Public Function sourceLabel(source As String)
        Return $"SOURCE: {source}"
    End Function

    Public Function quarryLabel(quarry As String)
        Return $"QUARRY: {quarry}"
    End Function

    Public Function itemLabel(itemDesc As String)
        Return $"{itemDesc}"
    End Function
End Class
