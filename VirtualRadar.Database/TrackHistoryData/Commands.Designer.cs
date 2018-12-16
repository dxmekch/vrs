﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualRadar.Database.TrackHistoryData {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Commands {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Commands() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VirtualRadar.Database.TrackHistoryData.Commands", typeof(Commands).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @countTrackHistories AS INTEGER;
        ///DECLARE @countTrackHistoryStates AS INTEGER;
        ///DECLARE @historyUtc AS DATETIME;
        ///
        ///DELETE FROM [TrackHistoryState]
        ///WHERE  [TrackHistoryID] = @trackHistoryID;
        ///SET @countTrackHistoryStates = CHANGES();
        ///
        ///SELECT @historyUtc = [CreatedUtc]
        ///FROM   [TrackHistory]
        ///WHERE  [TrackHistoryID] = @trackHistoryID;
        ///
        ///DELETE FROM [TrackHistory]
        ///WHERE  [TrackHistoryID] = @trackHistoryID;
        ///SET @countTrackHistories = CHANGES();
        ///
        ///SELECT @countTrackHistories     AS [CountTrackHis [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TrackHistory_Delete {
            get {
                return ResourceManager.GetString("TrackHistory_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [TrackHistoryState] (
        ///    [TrackHistoryID]
        ///   ,[TimestampUtc]
        ///   ,[SignalLevel]
        ///   ,[Callsign]
        ///   ,[IsCallsignSuspect]
        ///   ,[Latitude]
        ///   ,[Longitude]
        ///   ,[IsMlat]
        ///   ,[IsTisb]
        ///   ,[AltitudeFeet]
        ///   ,[AltitudeTypeID]
        ///   ,[TargetAltitudeFeet]
        ///   ,[AirPressureInHg]
        ///   ,[GroundSpeedKnots]
        ///   ,[SpeedTypeID]
        ///   ,[TrackDegrees]
        ///   ,[TargetTrack]
        ///   ,[TrackIsHeading]
        ///   ,[VerticalRateFeetMin]
        ///   ,[VerticalRateTypeID]
        ///   ,[SquawkOctal]
        ///   ,[IdentActive]
        ///) VALUES (
        ///    @TrackHistor [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TrackHistoryState_Insert {
            get {
                return ResourceManager.GetString("TrackHistoryState_Insert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE [TrackHistoryState]
        ///SET    [TrackHistoryID] =      @TrackHistoryID
        ///      ,[TimestampUtc] =        @TimestampUtc
        ///      ,[SignalLevel] =         @SignalLevel
        ///      ,[Callsign] =            @Callsign
        ///      ,[IsCallsignSuspect] =   @IsCallsignSuspect
        ///      ,[Latitude] =            @Latitude
        ///      ,[Longitude] =           @Longitude
        ///      ,[IsMlat] =              @IsMlat
        ///      ,[IsTisb] =              @IsTisb
        ///      ,[AltitudeFeet] =        @AltitudeFeet
        ///      ,[AltitudeTypeID] =      @AltitudeT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TrackHistoryState_Update {
            get {
                return ResourceManager.GetString("TrackHistoryState_Update", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --
        ///-- DatabaseVersion
        ///--
        ///CREATE TABLE IF NOT EXISTS [DatabaseVersion]
        ///(
        ///    [Version] INTEGER NOT NULL
        ///);
        ///
        ///
        ///--
        ///-- TrackHistory
        ///--
        ///CREATE TABLE IF NOT EXISTS [TrackHistory]
        ///(
        ///    [TrackHistoryID]    INTEGER PRIMARY KEY AUTOINCREMENT
        ///   ,[Icao]              VARCHAR(6) NOT NULL COLLATE NOCASE
        ///   ,[IsPreserved]       BIT NOT NULL
        ///   ,[CreatedUtc]        DATETIME NOT NULL
        ///   ,[UpdatedUtc]        DATETIME NOT NULL
        ///);
        ///
        ///CREATE INDEX IF NOT EXISTS [IX_TrackHistory_Icao] ON [TrackHistory] ([Icao] [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string UpdateSchema {
            get {
                return ResourceManager.GetString("UpdateSchema", resourceCulture);
            }
        }
    }
}
