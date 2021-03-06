﻿using System;
using System.Linq;
using System.Net;
using DestinySharp.Core.DataTypes;
using DestinySharp.Core.Entities;
using DestinySharp.Core.Entities.Responses;
using DestinySharp.Core.Entities.Responses.ResponseObject;
using Newtonsoft.Json;
using RestSharp;

namespace DestinySharp.Core
{
    /// <summary>
    ///     Main service explorer for the Destiny portion of the Bungie API
    /// </summary>
    public class DestinyServiceExplorer
    {
        private readonly RestClient _client = new RestClient("http://www.bungie.net/Platform/Destiny");

        public DestinyServiceExplorer(string apikey)
        {
            Apikey = apikey;
        }

        private string Apikey { get; }

        public string GetManifestDefinitions(DestinyManifestItem item)
        {
            string json = null;
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString("https://destiny.plumbing/");
            }

            if (json == null)
                throw new Exception("https://destiny.plumbing/ returned null. Is it down?");

            var response = JsonConvert.DeserializeObject<DestinyPlumbingRaw>(json);

            var no = Enum.GetName(typeof(DestinyManifestItem), item);

            if (no != null && response.en.collections.ContainsKey(no))
            {
                var itemval = response.en.collections[no];
                using (var webClient = new WebClient())
                {
                    json = webClient.DownloadString(itemval);
                }
                //Convert to object
                return json;
            }

            if (no != null && response.en.items.ContainsKey(no))
            {
                var itemval = response.en.items[no];
                if (itemval != null)
                {
                    using (var webClient = new WebClient())
                    {
                        json = webClient.DownloadString(itemval);
                    }
                    //Convert to object
                    return json;
                }
            }

            if (no != null && response.en.raw.ContainsKey(no))
            {
                var itemval = response.en.raw[no];
                if (itemval != null)
                {
                    using (var webClient = new WebClient())
                    {
                        json = webClient.DownloadString(itemval);
                    }
                    //Convert to object
                    return json;
                }
            }

            throw new Exception("Cannot find object " + nameof(item) + " in manifest!");
        }

        public AdvisorData GetAdvisorData(string membershipid, MembershipType type, bool definitions = false)
        {
            var request = new RestRequest($"/{(int) type}/Account/{membershipid}/Advisors/");
            request.AddHeader("X-API-KEY", Apikey);
            request.AddParameter("definitions", definitions);

            var response = _client.Execute(request);

            var r = JsonConvert.DeserializeObject<DestinyServiceObjectResponse<AdvisorData>>(response.Content);
            return r.Response.data;
        }

        /// <summary>
        ///     Gets activity history stats for given character
        /// </summary>
        /// <param name="membershipid">Valid membership id of the user</param>
        /// <param name="characterId">alid character id of the user</param>
        /// <param name="type">Valid console</param>
        /// <param name="activity">Activities in which to return</param>
        /// <param name="count">How many activities to return? Defaults to 25</param>
        /// <param name="page">What page of activity history? Default first(0)</param>
        /// <param name="definitions">Set to true if hashed object definitions should be returned in response</param>
        /// <returns>Returns ActivityData which has an array of "activities" that you can interate through.</returns>
        public ActivityData GetActivityHistoryStats(string membershipid, string characterId, MembershipType type,
            DestinyActivityMode activity, int count = 25, int page = 0, bool definitions = false)
        {
            var request = new RestRequest($"/Stats/ActivityHistory/{(int) type}/{membershipid}/{characterId}/");
            request.AddHeader("X-API-KEY", Apikey);
            request.AddParameter("mode", activity);
            request.AddParameter("count", count);
            request.AddParameter("page", page);
            request.AddParameter("definitions", definitions);

            var response = _client.Execute(request);
            var r = JsonConvert.DeserializeObject<DestinyServiceObjectResponse<ActivityData>>(response.Content);
            return r.Response.data;
        }

        /// <summary>
        ///     Get hashed character summary by name.
        /// </summary>
        /// <param name="displayName">Gamertag/PSN Name</param>
        /// <param name="type">Enum of which console.</param>
        /// <param name="definitions">Set to true if hashed object definitions should be returned in response</param>
        /// <returns></returns>
        public CharacterSummaryData GetCharacterSummary(string displayName, MembershipType type,
            bool definitions = false)
        {
            var request = new RestRequest($"/{(int) type}/Account/{GetMembershipId(displayName, type)}/Summary/");
            request.AddHeader("X-API-KEY", Apikey);
            request.AddParameter("definitions", definitions);

            var response = _client.Execute(request);

            var r = JsonConvert.DeserializeObject<DestinyServiceObjectResponse<CharacterSummaryData>>(response.Content);

            return r.Response.data;
        }

        /// <summary>
        ///     Directly query the destiny manifest. Might not be able to cast to any object. Use carefully
        /// </summary>
        /// <typeparam name="T">Type of object you are recieving</typeparam>
        /// <param name="hash">Ulong hash code of object you desire more info about</param>
        /// <param name="type">DestinyDefinitionType of what the hash is. If it isn't obvious, try InventoryItem first.</param>
        /// <param name="definitions">Set to true if hashed object definitions should be returned in response</param>
        /// <returns></returns>
        public T SingleQueryManifest<T>(ulong hash, DestinyDefinitionType type, bool definitions = false)
        {
            var request = new RestRequest($"/Manifest/{type}/{hash}/");
            request.AddHeader("X-API-KEY", Apikey);
            request.AddParameter("definitions", definitions);

            var response = _client.Execute<DestinyServiceObjectResponse<T>>(request);

            return response.Data.Response.data;
        }

        /// <summary>
        ///     Internal method used to grab the Membership id via name and console.
        /// </summary>
        /// <param name="displayName">Gamertag/PSN name</param>
        /// <param name="type">Enum of console</param>
        /// <returns></returns>
        internal string GetMembershipId(string displayName, MembershipType type)
        {
            var request = new RestRequest($"/{(int) type}/Stats/GetMembershipIdByDisplayName/{displayName}/");
            request.AddHeader("X-API-KEY", Apikey);
            var response = _client.Execute<DestinyServiceResponse>(request);

            return response.Data.Response;
        }

        public Player SearchDestinyPlayer(string displayName, MembershipType type)
        {
            var request = new RestRequest($"/SearchDestinyPlayer/{(int) type}/{displayName}");
            request.AddHeader("X-API-KEY", Apikey);
            var response = _client.Execute<Player>(request);

            return response.Data;
        }
    }
}