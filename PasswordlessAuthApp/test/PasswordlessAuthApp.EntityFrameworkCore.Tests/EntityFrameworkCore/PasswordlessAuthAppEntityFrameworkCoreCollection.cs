﻿using Xunit;

namespace PasswordlessAuthApp.EntityFrameworkCore;

[CollectionDefinition(PasswordlessAuthAppTestConsts.CollectionDefinitionName)]
public class PasswordlessAuthAppEntityFrameworkCoreCollection : ICollectionFixture<PasswordlessAuthAppEntityFrameworkCoreFixture>
{

}
