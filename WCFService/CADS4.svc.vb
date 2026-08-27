Imports Utility
Imports Utility.Types.ERRORTYPE

Public Class CADS4
    Implements IConfig

    Private m_Functions As New Functions
    Private m_Types As New Types
    Private m_MasterConfiguration As New Collections.SortedList

    Public Sub New()
        LoadMasterConfig()
    End Sub

    Public Sub LoadMasterConfig() Implements IConfig.LoadMasterConfig
        Dim MasterConfigFile As New ConfigFile
        Dim MasterConfigFilename As String

        ' Firstly load the configuration that tells us where to load the other configuration from
        MasterConfigFilename = Replace(My.Settings.MasterConfigFilename, "%APPPATH%", My.Application.Info.DirectoryPath)

        If IO.File.Exists(MasterConfigFilename) Then
            m_MasterConfiguration.Clear() ' Make certain that the collection is empty!
            MasterConfigFile.FilenameAndPath = MasterConfigFilename
            MasterConfigFile.GetSettings()

            If LastStatus.CADS_ERRORCODE = SUCCESS Then
                m_MasterConfiguration = MasterConfigFile.Contents
            Else
                ' There was an error retrieving the Master config contents!
                LastStatus.CADS_ERRORCODE = m_Functions.ErrorResult(CONFIG, Types.ERROR_CONFIG.SETTING_READ_ERROR)
            End If
        Else
            LastStatus.CADS_ERRORCODE = m_Functions.ErrorResult(CONFIG, Types.ERROR_CONFIG.MASTER_CONFIG_NOT_FOUND)
        End If
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IConfig.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IConfig.GetDataUsingDataContract
        If composite.BoolValue Then
            composite.StringValue = (composite.StringValue & "Suffix")
        End If
        Return composite
    End Function

    Public Function GetConfigCollection(ByVal ConfigName As String) As Collections.SortedList Implements IConfig.GetConfigCollection
        Dim Filename As String
        Dim ThisConfig As New ConfigFile

        Try
            Debug.Print(m_MasterConfiguration.Item(ConfigName).ToString)

            Filename = Replace(m_MasterConfiguration.Item(ConfigName).ToString, "%APPPATH%", My.Application.Info.DirectoryPath)

            ThisConfig.FilenameAndPath = Filename

            ThisConfig.GetSettings()

            Return ThisConfig.Contents
        Catch ex As Exception
            LastStatus.LastException = ex
            'LastStatus.CADS_ERRORCODE = 
            Return ThisConfig.Contents
        End Try
    End Function

    Public Sub SetConfigCollection(ByVal ConfigName As String, ByVal Configuration As Collections.SortedList) Implements IConfig.SetConfigCollection
        ' TODO:  Implement SetConfigCollection
    End Sub

End Class
