Module GlobalEnums
    Public Enum enumType
        ifInteger = 0
        ifString = 1
    End Enum

    Public Enum enumKPIView
        isViewing = 0
        isFromWarehouse = 1

    End Enum

    Public Class poWhatToUpdateType
        Public ReadOnly Property qty As String = "Qty"
        Public ReadOnly Property units As String = "Units"
        Public ReadOnly Property qty_units As String = "Qty and Units"
    End Class

    Public Class authType
        Public ReadOnly Property admin As String = "Admin"

    End Class

    Public Class tableNameType
        Public ReadOnly Property supply_table As String = "supply_db"
        Public ReadOnly Property eus_table As String = "eus"
    End Class

    Public cTableNameType As New tableNameType

End Module
