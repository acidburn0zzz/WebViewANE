﻿#region License

// Copyright 2017 Tua Rua Ltd.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// 
//  Additional Terms
//  No part, or derivative of this Air Native Extension's code is permitted 
//  to be sold as the basis of a commercially packaged Air Native Extension which 
//  undertakes the same purpose as this software. That is, a WebView for Windows, 
//  OSX and/or iOS and/or Android.
//  All Rights Reserved. Tua Rua Ltd.

#endregion

using System.Collections.Generic;
using FREObject = System.IntPtr;
using TuaRua.FreSharp;
namespace WebViewANELib {
    public class UrlRequest {
        public string Url { get; }
        public List<UrlRequestHeader> RequestHeaders { get; }
        public UrlRequest(FREObject freObject) {
            RequestHeaders = new List<UrlRequestHeader>();
            if (freObject.Type() == FreObjectTypeSharp.Null) return;
            Url = freObject.GetProp("url").AsString();
            var requestHeadersFre = new FREArray(freObject.GetProp("requestHeaders"));
            foreach (var requestHeader in requestHeadersFre) {
                RequestHeaders.Add(new UrlRequestHeader(requestHeader));
            }
        }

        public UrlRequest(string url) {
            Url = url;
            RequestHeaders = new List<UrlRequestHeader>();
        }
    }
}