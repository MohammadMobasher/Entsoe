
namespace Entsoe.Models
{
    public enum BusinessType
    {
        /// <summary>
        /// General Capacity Information
        /// </summary>
        A25,
        /// <summary>
        /// Already allocated capacity (AAC)
        /// </summary>
        A29,
        /// <summary>
        /// Requested capacity (without price)
        /// </summary>
        A43,
        /// <summary>
        /// System Operator redispatching
        /// </summary>
        A46,
        /// <summary>
        /// Planned maintenance
        /// </summary>
        A53,
        /// <summary>
        /// Unplanned outage
        /// </summary>
        A54,
        /// <summary>
        /// Internal redispatch
        /// </summary>
        A85,
        /// <summary>
        /// Frequency containment reserve
        /// </summary>
        A95,
        /// <summary>
        /// Automatic frequency restoration reserve
        /// </summary>
        A96,
        /// <summary>
        /// Manual frequency restoration reserve
        /// </summary>
        A97,
        /// <summary>
        /// Replacement reserve
        /// </summary>
        A98,
        /// <summary>
        /// Interconnector network evolution
        /// </summary>
        B01,
        /// <summary>
        /// Interconnector network dismantling
        /// </summary>
        B02,
        /// <summary>
        /// Counter trade
        /// </summary>
        B03,
        /// <summary>
        /// Congestion costs
        /// </summary>
        B04,
        /// <summary>
        /// Capacity allocated (including price)
        /// </summary>
        B05,
        /// <summary>
        /// Auction revenue
        /// </summary>
        B07,
        /// <summary>
        /// Total nominated capacity
        /// </summary>
        B08,
        /// <summary>
        /// Net position
        /// </summary>
        B09,
        /// <summary>
        /// Congestion income
        /// </summary>
        B10,
        /// <summary>
        /// Production unit
        /// </summary>
        B11,
        /// <summary>
        /// Area Control Error
        /// </summary>
        B33,
        /// <summary>
        /// Procured capacity
        /// </summary>
        B95,
        /// <summary>
        /// Shared Balancing Reserve Capacity
        /// </summary>
        C22,
        /// <summary>
        /// Share of reserve capacity
        /// </summary>
        C23,
        /// <summary>
        /// Actual reserve capacity
        /// </summary>
        C24,
    }
}
