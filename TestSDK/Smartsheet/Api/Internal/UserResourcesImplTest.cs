﻿using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Smartsheet.Api.Models;

	public class UserResourcesImplTest : ResourcesImplBase
	{

		private UserResourcesImpl userResources;

		[SetUp]
		public virtual void SetUp()
		{
			userResources = new UserResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestUserResourcesImpl()
		{
		}
		[Test]
		public virtual void TestListUsers()
		{
			server.setResponseBody("../../../TestSDK/resources/listUsers.json");

			IList<User> users = userResources.ListUsers(new List<string> { "john.doe@smartsheet.com" }, new PaginationParameters(false, 123, 117));
			Assert.NotNull(users);
			Assert.AreEqual(1, users.Count);
			Assert.AreEqual(94094820842L, (long)users[0].ID);
			Assert.AreEqual(true, users[0].Admin);
			Assert.AreEqual("john.doe@smartsheet.com", users[0].Email);
			Assert.AreEqual("John Doe", users[0].Name);
			Assert.AreEqual(true, users[0].LicensedSheetCreator);
			Assert.AreEqual(UserStatus.ACTIVE, users[0].Status);
		}

		[Test]
		public virtual void TestAddUser()
		{
			server.setResponseBody("../../../TestSDK/resources/addUser.json");

			User user = new User.AddUserBuilder().SetAdmin(false).SetEmail("NEW_USER_EMAIL").SetFirstName("John")
			.SetLastName("Doe").SetLicensedSheetCreator(true).Build();
			User newUser = userResources.AddUser(user, false);

			Assert.AreEqual("NEW_USER_EMAIL", newUser.Email);
			Assert.AreEqual("John Doe", newUser.Name);
			Assert.AreEqual(false, newUser.Admin);
			Assert.AreEqual(true, newUser.LicensedSheetCreator);
			Assert.AreEqual(1768423626696580L, (long)newUser.ID);
		}

		//[Test]
		//public virtual void TestAddUserUserBoolean()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/addUser.json");

		//	User user = new User();
		//	user.Admin = true;
		//	user.Email = "test@test.com";
		//	user.FirstName = "test425";
		//	user.LastName = "test425";
		//	user.LicensedSheetCreator = true;
		//	User newUser = userResources.AddUser(user, false);

		//	Assert.AreEqual("test@test.com", newUser.Email);
		//	Assert.AreEqual("test425 test425", newUser.Name);
		//	Assert.AreEqual(false, newUser.Admin);
		//	Assert.AreEqual(true, newUser.LicensedSheetCreator);
		//	Assert.AreEqual(3210982882338692L, (long)newUser.ID);
		//}

		[Test]
		public virtual void TestGetCurrentUser()
		{
			server.setResponseBody("../../../TestSDK/resources/getCurrentUser.json");

			UserProfile user = userResources.GetCurrentUser();
			Assert.AreEqual("john.doe@smartsheet.com", user.Email);
			Assert.AreEqual(48569348493401200L, (long)user.ID);
			Assert.AreEqual("John", user.FirstName);
			Assert.AreEqual("Doe", user.LastName);
		}

		[Test]
		public virtual void TestUpdateUser()
		{
			server.setResponseBody("../../../TestSDK/resources/updateUser.json");

			User user = new User.UpdateUserBuilder().SetAdmin(true).SetLicensedSheetCreator(true).Build();
			User updatedUser = userResources.UpdateUser(123L, user);
			Assert.AreEqual(true, updatedUser.Admin);
			Assert.AreEqual(true, updatedUser.LicensedSheetCreator);
		}

		[Test]
		public virtual void TestDeleteUser()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteUser.json");

			userResources.RemoveUser(123L, 456L, false, null);
		}
	}
}