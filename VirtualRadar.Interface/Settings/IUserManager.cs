﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualRadar.Interface.View;

namespace VirtualRadar.Interface.Settings
{
    /// <summary>
    /// The interface for the object that manages lists of users.
    /// </summary>
    public interface IUserManager : ISingleton<IUserManager>
    {
        /// <summary>
        /// Gets the name of the manager.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating that the manager can create new user accounts.
        /// </summary>
        bool CanCreateUsers { get; }

        /// <summary>
        /// Gets a value indicating that the manager can create a user and make use
        /// of a password hash supplied by VRS.
        /// </summary>
        /// <remarks>
        /// This is only used to port the old Basic Authentication user from legacy
        /// versions of VRS into IUserManager - it is expected that most 3rd party
        /// user repositories can't support this, in which case they should return
        /// false here.
        /// </remarks>
        bool CanCreateUsersWithHash { get; }

        /// <summary>
        /// Gets a value indicating that the manager can modify user accounts.
        /// </summary>
        bool CanEditUsers { get; }

        /// <summary>
        /// Gets a value indicating that the manager can change passwords on user accounts.
        /// </summary>
        bool CanChangePassword { get; }

        /// <summary>
        /// Gets a value indicating that the manager can enable or disable user accounts.
        /// </summary>
        bool CanChangeEnabledState { get; }

        /// <summary>
        /// Gets a value indicating that the manager can delete user accounts.
        /// </summary>
        bool CanDeleteUsers { get; }

        /// <summary>
        /// Gets a value indicating that the manager can retrieve a list of users.
        /// </summary>
        bool CanListUsers { get; }

        /// <summary>
        /// Initialises the manager.
        /// </summary>
        void Initialise();

        /// <summary>
        /// Shuts the manager down.
        /// </summary>
        void Shutdown();

        /// <summary>
        /// Validates the record passed across.
        /// </summary>
        /// <param name="results">A list of every problem with the record. If there are no problems then leave this alone.</param>
        /// <param name="record">The record to validate.</param>
        /// <param name="currentRecord">If the record is new then this will be null - otherwise it is the original record that is now being modified.</param>
        /// <param name="allRecords">If this is null then validate against the source of users - otherwise it is the entire list of users
        /// to validate against (the assumption being that this was originally returned by GetAll and may contain new, modified or deleted objects
        /// that have not yet been saved).</param>
        /// <returns></returns>
        /// <remarks>
        /// If the user manager does not support a particular feature, such as the changing of the enabled state or
        /// the changing of the password, then return an appropriate validation message. However the UI should have
        /// taken care not to let such modifications get this far.
        /// </remarks>
        void ValidateUser(List<ValidationResult> results, IUser record, IUser currentRecord, List<IUser> allRecords);

        /// <summary>
        /// Creates a new user. If <see cref="CanCreateUsers"/> is false then this should throw an exception when called.
        /// The user manager is expected to modify the record passed in to set IsPersisted to true and to fill in the unique ID.
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(IUser user);

        /// <summary>
        /// Creates a new user. If <see cref="CanCreateUsersWithHash"/> is false then this should throw an exception when called.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        void CreateUserWithHash(IUser user, Hash passwordHash);

        /// <summary>
        /// Edits an existing user. Throw an exception if the change is not permitted, otherwise modify the backing store to
        /// reflect the change in details for the user with the appropriate UniqueID.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPassword">This will be null if the password is to remain unchanged, otherwise it is the new password.</param>
        void UpdateUser(IUser user, string newPassword);

        /// <summary>
        /// Delete the user passed across. Throw an exception if the deletion is not permitted, otherwise remove the user
        /// from the backing store.
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(IUser user);

        /// <summary>
        /// Returns the user with the login name specified or null if no such user exists.
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns>The user record or null.</returns>
        IUser GetUserByLoginName(string loginName);

        /// <summary>
        /// Returns a collection of users that have the unique identifiers passed across. 
        /// </summary>
        /// <param name="uniqueIdentifiers"></param>
        /// <returns></returns>
        /// <remarks>
        /// It is very likely that you will be passed identifiers for users that do not exist,
        /// or had existed at one point but were since deleted. This is because the UI to maintain
        /// users is separate from the configuration UI. When you are passed a unique ID that no
        /// longer exists you should omit it entirely from the result - do not return null
        /// elements for them. If every unique ID passed across has no user associated with it
        /// then you would return an empty list.
        /// </remarks>
        IEnumerable<IUser> GetUsersByUniqueId(IEnumerable<string> uniqueIdentifiers);

        /// <summary>
        /// Returns a list of all users. Throw an exception if <see cref="CanListUsers"/> is false.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Do not return deleted users in this list. Do not consider the Enabled flag - this must
        /// return both enabled and disabled users.
        /// </remarks>
        IEnumerable<IUser> GetUsers();

        /// <summary>
        /// Returns a user record when given credentials supplied by the web site. Returns null
        /// if the credentials are invalid.
        /// </summary>
        /// <param name="loginName">The user name, as supplied by the web site.</param>
        /// <param name="passwordHash">The password hash created by the web site.</param>
        /// <param name="hashVersion">The version of the algorithm used by the web site to generate the hash,
        /// as supplied by the web site.</param>
        /// <returns></returns>
        IUser LoginWebsiteUser(string loginName, byte[] passwordHash, int hashVersion);

        /// <summary>
        /// Generates a Hash object given a service user's login name and password. These hashes are
        /// used by push rebroadcast servers to send feeds to a remote instance of VRS.
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Hash GenerateServiceUserHash(string loginName, string password);

        /// <summary>
        /// Returns a user record when given credentials supplied by a remote feed server. Returns
        /// null if the credentials are invalid.
        /// </summary>
        /// <param name="loginName">The user name, as supplied by the remote feed.</param>
        /// <param name="passwordHash">The password hash created by the remote feed.</param>
        /// <param name="hashVersion">The version of the algorithm used to generate the password hash, as
        /// supplied by the remote feed.</param>
        /// <returns></returns>
        IUser LoginServiceUser(string loginName, byte[] passwordHash, int hashVersion);
    }
}
