﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinySharp.Core
{
    /// <summary>
    /// Object response contains special generic typing to properly create the "Response.data" object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DestinyServiceObjectResponse<T>
    {
        public Response<T> Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public MessageData MessageData { get; set; }
    }
    public class MessageData
    {
        dynamic data { get; set; }
    }
    public class Response<T>
    {
        public T data { get; set; }
        /// <summary>
        /// Null if definitions bool on request is false
        /// </summary>
        public Definitions definitions { get; set; }
    }

    public class Definitions
    {
        public Dictionary<string, DefinitionActivity> activities { get; set; }
        public Dictionary<string, DefinitionDestinations> destinations { get; set; }
        public Dictionary<string, DefinitionPlaces> places { get; set; }
        public Dictionary<string, DefinitionActivityTypes> activityTypes { get; set; }
        public Dictionary<string, DefinitionItems> items { get; set; }
        public Dictionary<string, DefinitionBuckets> buckets { get; set; }
        public Dictionary<string, DefinitionStats> stats { get; set; }
        public Dictionary<string, DefinitionPerks> perks { get; set; }
        public Dictionary<string, DefinitionTalentGrids> talentGrids { get; set; }
        public Dictionary<string, DefinitionStatGroups> statGroups { get; set; }
        public Dictionary<string, object> progressionMappings { get; set; }
        public Dictionary<string, DefinitionItemCategories> itemCategories { get; set; }
        public Dictionary<string, DefinitionSources> sources { get; set; }
        public Dictionary<string, object> objectives { get; set; }
        public Dictionary<string, object> progressions { get; set; }
        public Dictionary<string, object> damageTypes { get; set; }
        public Dictionary<string, object> materialRequirements { get; set; }
        public Dictionary<string, object> unlockValues { get; set; }
        public Dictionary<string, object> vendorDetails { get; set; }
        public Dictionary<string, object> locations { get; set; }
        public Dictionary<string, object> factions { get; set; }
        public Dictionary<string, object> events { get; set; }
        public Dictionary<string, object> vendorCategories { get; set; }
        public Dictionary<string, object> vendorSummaries { get; set; }
        public Dictionary<string, object> books { get; set; }
        public Dictionary<string, object> activityBundles { get; set; }
    }
#region Definitions
    #region Activity
    public class DefinitionActivity
    {
        public ulong activityHash { get; set; }
        public string activityName { get; set; }
        public string activityDescription { get; set; }
        public string icon { get; set; }
        public string releaseIcon { get; set; }
        public int releaseTime { get; set; }
        public int activityLevel { get; set; }
        public ulong completionFlagHash { get; set; }
        public int activityPower { get; set; }
        public int minParty { get; set; }
        public int maxParty { get; set; }
        public int maxPlayers { get; set; }
        public ulong destinationHash { get; set; }
        public ulong placeHash { get; set; }
        public ulong activityTypeHash { get; set; }
        public int tier { get; set; }
        public string pgcrImage { get; set; }
        public Reward[] rewards { get; set; }
        public List<object> skulls { get; set; }
        public bool isPlaylist { get; set; }
        public bool isMatchmade { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class Reward
    {
        public Rewarditem[] rewardItems { get; set; }
    }

    public class Rewarditem
    {
        public int itemHash { get; set; }
        public int value { get; set; }
    }
    public class DefinitionActivityRewardItem
    {
        public ulong itemHash { get; set; }
        public int value { get; set; }
    }
    #endregion
    public class DefinitionDestinations
    {
        public ulong destinationHash { get; set; }
        public string destinationName { get; set; }
        public string destinationDescription { get; set; }
        public string icon { get; set; }
        public ulong placeHash { get; set; }
        public string destinationIdentifier { get; set; }
        public string locationIdentifier { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionPlaces
    {
        public ulong placeHash { get; set; }
        public string placeName { get; set; }
        public string placeDescription { get; set; }
        public string icon { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionActivityTypes
    {
        public int activityTypeHash { get; set; }
        public string identifier { get; set; }
        public string activityTypeName { get; set; }
        public string activityTypeDescription { get; set; }
        public string icon { get; set; }
        public string activeBackgroundVirtualPath { get; set; }
        public string completedBackgroundVirtualPath { get; set; }
        public string hiddenOverrideVirtualPath { get; set; }
        public string tooltipBackgroundVirtualPath { get; set; }
        public string enlargedActiveBackgroundVirtualPath { get; set; }
        public string enlargedCompletedBackgroundVirtualPath { get; set; }
        public string enlargedHiddenOverrideVirtualPath { get; set; }
        public string enlargedTooltipBackgroundVirtualPath { get; set; }
        public int order { get; set; }
        public int hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionItems
    {
        public int itemHash { get; set; }
        public string itemName { get; set; }
        public string icon { get; set; }
        public bool hasIcon { get; set; }
        public string secondaryIcon { get; set; }
        public string actionName { get; set; }
        public string actionDescription { get; set; }
        public bool hasAction { get; set; }
        public bool deleteOnAction { get; set; }
        public string tierTypeName { get; set; }
        public int tierType { get; set; }
        public ulong bucketTypeHash { get; set; }
        public int primaryBaseStatHash { get; set; }
        public object stats { get; set; }
        public object[] perkHashes { get; set; }
        public int specialItemType { get; set; }
        public int talentGridHash { get; set; }
        public bool hasGeometry { get; set; }
        public int statGroupHash { get; set; }
        public object[] itemLevels { get; set; }
        public int qualityLevel { get; set; }
        public bool equippable { get; set; }
        public bool instanced { get; set; }
        public int rewardItemHash { get; set; }
        public object values { get; set; }
        public int itemType { get; set; }
        public int itemSubType { get; set; }
        public int classType { get; set; }
        public object[] itemCategoryHashes { get; set; }
        public object[] sourceHashes { get; set; }
        public bool nonTransferrable { get; set; }
        public int exclusive { get; set; }
        public int maxStackSize { get; set; }
        public int itemIndex { get; set; }
        public object[] setItemHashes { get; set; }
        public string tooltipStyle { get; set; }
        public int questlineItemHash { get; set; }
        public bool needsFullCompletion { get; set; }
        public object[] objectiveHashes { get; set; }
        public bool allowActions { get; set; }
        public int questTrackingUnlockValueHash { get; set; }
        public int bountyResetUnlockHash { get; set; }
        public int uniquenessHash { get; set; }
        public bool showActiveNodesInTooltip { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionBuckets
    {
        public ulong bucketHash { get; set; }
        public int scope { get; set; }
        public int category { get; set; }
        public int bucketOrder { get; set; }
        public string bucketIdentifier { get; set; }
        public int itemCount { get; set; }
        public int location { get; set; }
        public bool hasTransferDestination { get; set; }
        public bool enabled { get; set; }
        public bool fifo { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionPerks {
        public ulong perkHash { get; set; }
        public string displayIcon { get; set; }
        public bool isDisplayable { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionStats
    {
        public ulong statHash { get; set; }
        public string statName { get; set; }
        public string statDescription { get; set; }
        public string icon { get; set; }
        public string statIdentifier { get; set; }
        public int aggregationType { get; set; }
        public bool hasComputedBlock { get; set; }
        public bool interpolate { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionTalentGrids
    {
        public ulong gridHash { get; set; }
        public int maxGridLevel { get; set; }
        public int gridLevelPerColumn { get; set; }
        public ulong progressionHash { get; set; }
        public object[] nodes { get; set; }
        public int calcMaxGridLevel { get; set; }
        public int calcProgressToMaxLevel { get; set; }
        public object[] exclusiveSets { get; set; }
        public object[] independentNodeIndexes { get; set; }
        public int maximumRandomMaterialRequirements { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
#region StatGroups
    public class DefinitionStatGroups
    {
        public ulong statGroupHash { get; set; }
        public int maximumValue { get; set; }
        public int uiPosition { get; set; }
        public List<DefinitionStatGroupsScaledStats> scaledStats { get; set; }
        public object[] overrides { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionStatGroupsScaledStats
    {
        public ulong statHash { get; set; }
        public int maximumValue { get; set; }
        public bool displayAsNumeric { get; set; }
        public List<DefinitionStatGroupsScaledStatsInterpolation> displayInterpolation { get; set; }
    }
    public class DefinitionStatGroupsScaledStatsInterpolation
    {
       public int value { get; set; }
       public int weight { get; set; }
    }
#endregion
    public class DefinitionItemCategories
    {
        public ulong itemCategoryHash { get; set; }
        public string identifier { get; set; }
        public bool visible { get; set; }
        public string title { get; set; }
        public string shortTitle { get; set; }
        public string description { get; set; }
        public int grantDestinyItemType { get; set; }
        public int grantDestinySubType { get; set; }
        public int grantDestinyClass { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionSources
    {
        public ulong sourceHash { get; set; }
        public int category { get; set; }
        public string identifier { get; set; }
        public string sourceName { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public bool redacted { get; set; }
    }
    public class DefinitionObjectives
    {
        public ulong objectiveHash { get; set; }
        public ulong unlockValueHash { get; set; }
        public int completionValue { get; set; }
        public ulong vendorHash { get; set; }
        public ulong vendorCategoryHash { get; set; }
        public string displayDescription { get; set; }
        public ulong locationHash { get; set; }
        public bool allowNegativeValue { get; set; }
        public bool allowValueChangeWhenCompleted { get; set; }
        public bool isCountingDownward { get; set; }
        public int valueStyle { get; set; }
        public ulong hash { get; set; }
        public int index { get; set; }
        public string contentIdentifier { get; set; }
        public bool redacted { get; set; }
    }
#endregion
}
