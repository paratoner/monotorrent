﻿//
// ILocalPeerDiscovery.cs
//
// Authors:
//   Alan McGovern alan.mcgovern@gmail.com
//
// Copyright (C) 2019 Alan McGovern
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using System;
using System.Net;
using System.Threading.Tasks;

namespace MonoTorrent.Client
{
    public interface ILocalPeerDiscovery : IListener
    {
        TimeSpan MinimumAnnounceInternal { get; }
        TimeSpan AnnounceInternal { get; }

        /// <summary>
        /// This event is raised whenever a peer is discovered.
        /// </summary>
        event EventHandler<LocalPeerFoundEventArgs> PeerFound;

        /// <summary>
        /// Send an announce request for this InfoHash to all available network adapters.
        /// </summary>
        /// <param name="infoHash"></param>
        /// <param name="listeningPort">The TCP port used to accept incoming connections.</param>
        /// <returns></returns>
        Task Announce (InfoHash infoHash, IPEndPoint listeningPort);
    }
}
