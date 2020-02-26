Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Text

    <Serializable(), ComVisible(True)> _
    Public Enum ObjectSafetyOptions
        INTERFACESAFE_FOR_UNTRUSTED_CALLER = &H1
        INTERFACESAFE_FOR_UNTRUSTED_DATA = &H2
        INTERFACE_USES_DISPEX = &H4
        INTERFACE_USES_SECURITY_MANAGER = &H8
    End Enum

    '
    ' MS IObjectSafety Interface definition
    '
<ComImport(), Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
Public Interface IObjectSafety
    <PreserveSig()> _
    Function GetInterfaceSafetyOptions(ByRef iid As Guid, ByRef pdwSupportedOptions As Integer, ByRef pdwEnabledOptions As Integer) As Long

    <PreserveSig()> _
    Function SetInterfaceSafetyOptions(ByRef iid As Guid, ByVal dwOptionSetMask As Integer, ByVal dwEnabledOptions As Integer) As Long
End Interface

    '
    ' Provides a default Implementation for
    ' safe scripting.
    ' This basically means IE won't complain about the
    ' ActiveX object not being safe
    '
Friend Class IObjectSafetyImpl
    Implements IObjectSafety
    Private m_options As ObjectSafetyOptions = ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_CALLER Or ObjectSafetyOptions.INTERFACESAFE_FOR_UNTRUSTED_DATA

#Region "[IObjectSafety implementation]"
    Public Function GetInterfaceSafetyOptions(ByRef iid As Guid, ByRef pdwSupportedOptions As Integer, ByRef pdwEnabledOptions As Integer) As Long Implements IObjectSafety.GetInterfaceSafetyOptions
        pdwSupportedOptions = CInt(m_options)
        pdwEnabledOptions = CInt(m_options)
        Return 0
    End Function

    Public Function SetInterfaceSafetyOptions(ByRef iid As Guid, ByVal dwOptionSetMask As Integer, ByVal dwEnabledOptions As Integer) As Long Implements IObjectSafety.SetInterfaceSafetyOptions
        Return 0
    End Function
#End Region
End Class
