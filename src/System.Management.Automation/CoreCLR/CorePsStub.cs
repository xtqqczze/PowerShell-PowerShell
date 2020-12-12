// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;

using Microsoft.Win32;

#pragma warning disable 1591, 1572, 1571, 1573, 1587, 1570, 0067

#region PS_STUBS
// Include PS types that are not needed for PowerShell on CSS

namespace System.Management.Automation
{
    #region PSTransaction

    /// <summary>
    /// We don't need PSTransaction related types on CSS because System.Transactions
    /// namespace is not available in CoreCLR.
    /// </summary>
    public sealed class PSTransactionContext : IDisposable
    {
        internal PSTransactionContext(Internal.PSTransactionManager transactionManager) { }

        public void Dispose() { }
    }

    /// <summary>
    /// The severity of error that causes PowerShell to automatically
    /// rollback the transaction.
    /// </summary>
    public enum RollbackSeverity
    {
        /// <summary>
        /// Non-terminating errors or worse.
        /// </summary>
        Error,

        /// <summary>
        /// Terminating errors or worse.
        /// </summary>
        TerminatingError,

        /// <summary>
        /// Do not rollback the transaction on error.
        /// </summary>
        Never
    }

    #endregion PSTransaction
}

namespace System.Management.Automation.Internal
{
    /// <summary>
    /// We don't need PSTransaction related types on CSS because System.Transactions
    /// namespace is not available in CoreCLR.
    /// </summary>
    internal sealed class PSTransactionManager : IDisposable
    {
        /// <summary>
        /// Determines if you have a transaction that you can set active and work on.
        /// </summary>
        /// <remarks>
        /// Always return false in CoreCLR
        /// </remarks>
        internal bool HasTransaction
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if the last transaction has been committed.
        /// </summary>
        internal bool IsLastTransactionCommitted
        {
            get
            {
                throw new NotImplementedException("IsLastTransactionCommitted");
            }
        }

        /// <summary>
        /// Determines if the last transaction has been rolled back.
        /// </summary>
        internal bool IsLastTransactionRolledBack
        {
            get
            {
                throw new NotImplementedException("IsLastTransactionRolledBack");
            }
        }

        /// <summary>
        /// Gets the rollback preference for the active transaction.
        /// </summary>
        internal RollbackSeverity RollbackPreference
        {
            get
            {
                throw new NotImplementedException("RollbackPreference");
            }
        }

        /// <summary>
        /// Called by engine APIs to ensure they are protected from
        /// ambient transactions.
        /// </summary>
        /// <remarks>
        /// Always return null in CoreCLR
        /// </remarks>
        internal static IDisposable GetEngineProtectionScope()
        {
            return null;
        }

        /// <summary>
        /// Aborts the current transaction, no matter how many subscribers are part of it.
        /// </summary>
        internal void Rollback(bool suppressErrors)
        {
            throw new NotImplementedException("Rollback");
        }

        public void Dispose() { }
    }
}

namespace Microsoft.PowerShell.Commands.Internal
{
    using System.Security.AccessControl;
    using System.Security.Principal;

    #region TransactedRegistryKey

    internal abstract class TransactedRegistryKey : IDisposable
    {
        public void Dispose() { }

        public void SetValue(string name, object value)
        {
            throw new NotImplementedException("SetValue(string name, obj value) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public void SetValue(string name, object value, RegistryValueKind valueKind)
        {
            throw new NotImplementedException("SetValue(string name, obj value, RegistryValueKind valueKind) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public string[] GetValueNames()
        {
            throw new NotImplementedException("GetValueNames() is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public void DeleteValue(string name)
        {
            throw new NotImplementedException("DeleteValue(string name) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public string[] GetSubKeyNames()
        {
            throw new NotImplementedException("GetSubKeyNames() is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public TransactedRegistryKey CreateSubKey(string subkey)
        {
            throw new NotImplementedException("CreateSubKey(string subkey) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public TransactedRegistryKey OpenSubKey(string name, bool writable)
        {
            throw new NotImplementedException("OpenSubKey(string name, bool writeable) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public void DeleteSubKeyTree(string subkey)
        {
            throw new NotImplementedException("DeleteSubKeyTree(string subkey) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public object GetValue(string name)
        {
            throw new NotImplementedException("GetValue(string name) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public object GetValue(string name, object defaultValue, RegistryValueOptions options)
        {
            throw new NotImplementedException("GetValue(string name, object defaultValue, RegistryValueOptions options) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public RegistryValueKind GetValueKind(string name)
        {
            throw new NotImplementedException("GetValueKind(string name) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public void Close()
        {
            throw new NotImplementedException("Close() is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public abstract string Name { get; }

        public abstract int SubKeyCount { get; }

        public void SetAccessControl(ObjectSecurity securityDescriptor)
        {
            throw new NotImplementedException("SetAccessControl(ObjectSecurity securityDescriptor) is not implemented. TransactedRegistry related APIs should not be used.");
        }

        public ObjectSecurity GetAccessControl(AccessControlSections includeSections)
        {
            throw new NotImplementedException("GetAccessControl(AccessControlSections includeSections) is not implemented. TransactedRegistry related APIs should not be used.");
        }
    }

    internal sealed class TransactedRegistry
    {
        internal static readonly TransactedRegistryKey LocalMachine;
        internal static readonly TransactedRegistryKey ClassesRoot;
        internal static readonly TransactedRegistryKey Users;
        internal static readonly TransactedRegistryKey CurrentConfig;
        internal static readonly TransactedRegistryKey CurrentUser;
    }

    internal sealed class TransactedRegistrySecurity : ObjectSecurity
    {
        public override Type AccessRightType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Type AccessRuleType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Type AuditRuleType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
        {
            throw new NotImplementedException();
        }

        public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
        {
            throw new NotImplementedException();
        }

        protected override bool ModifyAccess(AccessControlModification modification, AccessRule rule, out bool modified)
        {
            throw new NotImplementedException();
        }

        protected override bool ModifyAudit(AccessControlModification modification, AuditRule rule, out bool modified)
        {
            throw new NotImplementedException();
        }
    }

    #endregion TransactedRegistryKey
}

#endregion PS_STUBS

// -- Will port the actual PS component [update: Not necessarily porting all PS components listed here]
#region TEMPORARY

namespace System.Management.Automation.Internal
{
    using Microsoft.PowerShell.Commands;

    /// <summary>
    /// TODO:CORECLR - The actual PowerShellModuleAssemblyAnalyzer cannot be enabled because we don't have 'System.Reflection.Metadata.dll' in our branch yet.
    /// This stub will be removed once we enable the actual 'PowerShellModuleAssemblyAnalyzer'.
    /// </summary>
    internal static class PowerShellModuleAssemblyAnalyzer
    {
        internal static BinaryAnalysisResult AnalyzeModuleAssembly(string path, out Version assemblyVersion)
        {
            assemblyVersion = new Version("0.0.0.0");
            return null;
        }
    }
}

namespace System.Management.Automation
{
    using Microsoft.Win32;

    #region RegistryStringResourceIndirect

    internal sealed class RegistryStringResourceIndirect : IDisposable
    {
        internal static RegistryStringResourceIndirect GetResourceIndirectReader()
        {
            return new RegistryStringResourceIndirect();
        }

        /// <summary>
        /// Dispose method unloads the app domain that was
        /// created in the constructor.
        /// </summary>
        public void Dispose()
        {
        }

        internal string GetResourceStringIndirect(
            string assemblyName,
            string modulePath,
            string baseNameRIDPair)
        {
            throw new NotImplementedException("RegistryStringResourceIndirect.GetResourceStringIndirect - 3 params");
        }

        internal string GetResourceStringIndirect(
            RegistryKey key,
            string valueName,
            string assemblyName,
            string modulePath)
        {
            throw new NotImplementedException("RegistryStringResourceIndirect.GetResourceStringIndirect - 4 params");
        }
    }

    #endregion
}

#if UNIX

namespace System.Management.Automation.ComInterop
{
    using System.Dynamic;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides helper methods to bind COM objects dynamically.
    /// </summary>
    /// <remarks>
    /// COM is not supported on Unix platforms. So this is a stub type.
    /// </remarks>
    internal static class ComBinder
    {
        /// <summary>
        /// Tries to perform binding of the dynamic get index operation.
        /// </summary>
        /// <remarks>
        /// Always return false in CoreCLR.
        /// </remarks>
        public static bool TryBindGetIndex(GetIndexBinder binder, DynamicMetaObject instance, DynamicMetaObject[] args, out DynamicMetaObject result)
        {
            result = null;
            return false;
        }

        /// <summary>
        /// Tries to perform binding of the dynamic set index operation.
        /// </summary>
        /// <remarks>
        /// Always return false in CoreCLR.
        /// </remarks>
        public static bool TryBindSetIndex(SetIndexBinder binder, DynamicMetaObject instance, DynamicMetaObject[] args, DynamicMetaObject value, out DynamicMetaObject result)
        {
            result = null;
            return false;
        }

        /// <summary>
        /// Tries to perform binding of the dynamic get member operation.
        /// </summary>
        /// <remarks>
        /// Always return false in CoreCLR.
        /// </remarks>
        public static bool TryBindGetMember(GetMemberBinder binder, DynamicMetaObject instance, out DynamicMetaObject result, bool delayInvocation)
        {
            result = null;
            return false;
        }

        /// <summary>
        /// Tries to perform binding of the dynamic set member operation.
        /// </summary>
        /// <remarks>
        /// Always return false in CoreCLR.
        /// </remarks>
        public static bool TryBindSetMember(SetMemberBinder binder, DynamicMetaObject instance, DynamicMetaObject value, out DynamicMetaObject result)
        {
            result = null;
            return false;
        }

        /// <summary>
        /// Tries to perform binding of the dynamic invoke member operation.
        /// </summary>
        /// <remarks>
        /// Always return false in CoreCLR.
        /// </remarks>
        public static bool TryBindInvokeMember(InvokeMemberBinder binder, bool isSetProperty, DynamicMetaObject instance, DynamicMetaObject[] args, out DynamicMetaObject result)
        {
            result = null;
            return false;
        }
    }

    internal class VarEnumSelector
    {
        internal static Type GetTypeForVarEnum(VarEnum vt)
        {
            throw new PlatformNotSupportedException();
        }
    }
}

namespace System.Management.Automation.Security
{
    /// <summary>
    /// Application white listing security policies only affect Windows OSs.
    /// </summary>
    internal sealed class SystemPolicy
    {
        private SystemPolicy() { }

        /// <summary>
        /// Gets the system lockdown policy.
        /// </summary>
        /// <remarks>Always return SystemEnforcementMode.None in CSS (trusted)</remarks>
        public static SystemEnforcementMode GetSystemLockdownPolicy()
        {
            return SystemEnforcementMode.None;
        }

        /// <summary>
        /// Gets lockdown policy as applied to a file.
        /// </summary>
        /// <remarks>Always return SystemEnforcementMode.None in CSS (trusted)</remarks>
        public static SystemEnforcementMode GetLockdownPolicy(string path, System.Runtime.InteropServices.SafeHandle handle)
        {
            return SystemEnforcementMode.None;
        }

        internal static bool IsClassInApprovedList(Guid clsid)
        {
            throw new NotImplementedException("SystemPolicy.IsClassInApprovedList not implemented");
        }
    }

    /// <summary>
    /// How the policy is being enforced.
    /// </summary>
    internal enum SystemEnforcementMode
    {
        /// Not enforced at all
        None = 0,

        /// Enabled - allow, but audit
        Audit = 1,

        /// Enabled, enforce restrictions
        Enforce = 2
    }
}

// Porting note: Tracing is absolutely not available on Linux
namespace System.Management.Automation.Tracing
{
    using System.Diagnostics.CodeAnalysis;
    using System.Management.Automation.Internal;

    /// <summary>
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
    public abstract class EtwActivity
    {
        /// <summary>
        /// </summary>
        /// <param name="activityId"></param>
        public static bool SetActivityId(Guid activityId)
        {
            return false;
        }

        /// <summary>
        /// </summary>
        public static Guid CreateActivityId()
        {
            return Guid.Empty;
        }

        /// <summary>
        /// </summary>
        public static Guid GetActivityId()
        {
            return Guid.Empty;
        }
    }

    public enum PowerShellTraceTask
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// CreateRunspace.
        /// </summary>
        CreateRunspace = 1,

        /// <summary>
        /// ExecuteCommand.
        /// </summary>
        ExecuteCommand = 2,

        /// <summary>
        /// Serialization.
        /// </summary>
        Serialization = 3,

        /// <summary>
        /// PowerShellConsoleStartup.
        /// </summary>
        PowerShellConsoleStartup = 4,
    }

    /// <summary>
    /// Defines Keywords.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1028")]
    [Flags]
    public enum PowerShellTraceKeywords : ulong
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Runspace.
        /// </summary>
        Runspace = 0x1,

        /// <summary>
        /// Pipeline.
        /// </summary>
        Pipeline = 0x2,

        /// <summary>
        /// Protocol.
        /// </summary>
        Protocol = 0x4,

        /// <summary>
        /// Transport.
        /// </summary>
        Transport = 0x8,

        /// <summary>
        /// Host.
        /// </summary>
        Host = 0x10,

        /// <summary>
        /// Cmdlets.
        /// </summary>
        Cmdlets = 0x20,

        /// <summary>
        /// Serializer.
        /// </summary>
        Serializer = 0x40,

        /// <summary>
        /// Session.
        /// </summary>
        Session = 0x80,

        /// <summary>
        /// ManagedPlugIn.
        /// </summary>
        ManagedPlugIn = 0x100,

        /// <summary>
        /// </summary>
        UseAlwaysDebug = 0x2000000000000000,

        /// <summary>
        /// </summary>
        UseAlwaysOperational = 0x8000000000000000,

        /// <summary>
        /// </summary>
        UseAlwaysAnalytic = 0x4000000000000000,
    }

    public sealed partial class Tracer : System.Management.Automation.Tracing.EtwActivity
    {
        static Tracer() { }

        public void EndpointRegistered(string endpointName, string endpointType, string registeredBy)
        {
        }

        public void EndpointUnregistered(string endpointName, string unregisteredBy)
        {
        }

        public void EndpointDisabled(string endpointName, string disabledBy)
        {
        }

        public void EndpointEnabled(string endpointName, string enabledBy)
        {
        }

        public void EndpointModified(string endpointName, string modifiedBy)
        {
        }

        public void BeginContainerParentJobExecution(Guid containerParentJobInstanceId)
        {
        }

        public void BeginProxyJobExecution(Guid proxyJobInstanceId)
        {
        }

        public void ProxyJobRemoteJobAssociation(Guid proxyJobInstanceId, Guid containerParentJobInstanceId)
        {
        }

        public void EndProxyJobExecution(Guid proxyJobInstanceId)
        {
        }

        public void BeginProxyJobEventHandler(Guid proxyJobInstanceId)
        {
        }

        public void EndProxyJobEventHandler(Guid proxyJobInstanceId)
        {
        }

        public void BeginProxyChildJobEventHandler(Guid proxyChildJobInstanceId)
        {
        }

        public void EndContainerParentJobExecution(Guid containerParentJobInstanceId)
        {
        }
    }

    public sealed class PowerShellTraceSource : IDisposable
    {
        internal PowerShellTraceSource(PowerShellTraceTask task, PowerShellTraceKeywords keywords)
        {
        }

        public void Dispose()
        {
        }

        public bool WriteMessage(string message)
        {
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="message1"></param>
        /// <param name="message2"></param>
        public bool WriteMessage(string message1, string message2)
        {
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="instanceId"></param>
        public bool WriteMessage(string message, Guid instanceId)
        {
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="workflowId"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        public void WriteMessage(string className, string methodName, Guid workflowId, string message, params string[] parameters)
        {
            return;
        }

        /// <summary>
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="workflowId"></param>
        /// <param name="job"></param>
        /// <param name="message"></param>
        /// <param name="parameters"></param>
        public void WriteMessage(string className, string methodName, Guid workflowId, Job job, string message, params string[] parameters)
        {
            return;
        }

        public bool TraceException(Exception exception)
        {
            return false;
        }
    }

    /// <summary>
    /// TraceSourceFactory will return an instance of TraceSource every time GetTraceSource method is called.
    /// </summary>
    public static class PowerShellTraceSourceFactory
    {
        /// <summary>
        /// Returns an instance of BaseChannelWriter.
        /// If the Etw is not supported by the platform it will return NullWriter.Instance
        ///
        /// A Task and a set of Keywords can be specified in the GetTraceSource method (See overloads).
        ///    The supplied task and keywords are used to pass to the Etw provider in case they are
        /// not defined in the manifest file.
        /// </summary>
        public static PowerShellTraceSource GetTraceSource()
        {
            return new PowerShellTraceSource(PowerShellTraceTask.None, PowerShellTraceKeywords.None);
        }

        /// <summary>
        /// Returns an instance of BaseChannelWriter.
        /// If the Etw is not supported by the platform it will return NullWriter.Instance
        ///
        /// A Task and a set of Keywords can be specified in the GetTraceSource method (See overloads).
        ///    The supplied task and keywords are used to pass to the Etw provider in case they are
        /// not defined in the manifest file.
        /// </summary>
        public static PowerShellTraceSource GetTraceSource(PowerShellTraceTask task)
        {
            return new PowerShellTraceSource(task, PowerShellTraceKeywords.None);
        }

        /// <summary>
        /// Returns an instance of BaseChannelWriter.
        /// If the Etw is not supported by the platform it will return NullWriter.Instance
        ///
        /// A Task and a set of Keywords can be specified in the GetTraceSource method (See overloads).
        ///    The supplied task and keywords are used to pass to the Etw provider in case they are
        /// not defined in the manifest file.
        /// </summary>
        public static PowerShellTraceSource GetTraceSource(PowerShellTraceTask task, PowerShellTraceKeywords keywords)
        {
            return new PowerShellTraceSource(task, keywords);
        }
    }
}

#endif

namespace Microsoft.PowerShell
{
    internal static class NativeCultureResolver
    {
        internal static void SetThreadUILanguage(Int16 langId) { }

        internal static CultureInfo UICulture
        {
            get
            {
                return CultureInfo.CurrentUICulture; // this is actually wrong, but until we port "hostifaces\NativeCultureResolver.cs" to Nano, this will do and will help avoid build break.
            }
        }

        internal static CultureInfo Culture
        {
            get
            {
                return CultureInfo.CurrentCulture; // this is actually wrong, but until we port "hostifaces\NativeCultureResolver.cs" to Nano, this will do and will help avoid build break.
            }
        }
    }
}

#endregion TEMPORARY

#pragma warning restore 1591, 1572, 1571, 1573, 1587, 1570, 0067
