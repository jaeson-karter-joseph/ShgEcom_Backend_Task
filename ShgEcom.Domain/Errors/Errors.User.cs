﻿using ErrorOr;

namespace ShgEcom.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email Already Exists.");

        }
    }
}
