﻿using System;
using System.Web.SessionState;
using DevDefined.OAuth.Framework;

namespace Xero.ScreencastWeb.Services
{
    public static class HttpSessionStateExtensions
    {
        public static void SetRequestToken(this HttpSessionState session, IToken token)
        {
            session["oauth_request_token"] = (token == null) ? null : token.Token;
            session["oauth_request_secret"] = (token == null) ? null : token.TokenSecret;
        }

        public static IToken GetRequestToken(this HttpSessionState session)
        {
            if (session["oauth_request_token"] == null)
            {
                return null;
            }

            return new TokenBase
            {
                Token = Convert.ToString(session["oauth_request_token"]),
                TokenSecret = Convert.ToString(session["oauth_request_secret"])
            };
        }

        public static void SetAccessToken(this HttpSessionState session, IToken token)
        {
            session["oauth_access_token"] = (token == null) ? null : token.Token;
            session["oauth_access_secret"] = (token == null) ? null : token.TokenSecret;
        }

        public static IToken GetAccessToken(this HttpSessionState session)
        {
            if (session["oauth_access_token"] == null)
            {
                return null;
            }

            return new TokenBase
            {
                Token = Convert.ToString(session["oauth_access_token"]),
                TokenSecret = Convert.ToString(session["oauth_access_secret"])
            };
        }
    }
}