
namespace Entsoe.Models
{
    public enum ProccessType
    {
        /// <summary>
        /// Day ahead
        /// </summary>
        A01,
        /// <summary>
        /// Intra day incremental
        /// </summary>
        A02,
        /// <summary>
        /// Realised
        /// </summary>
        A16,
        /// <summary>
        /// Intraday total
        /// </summary>
        A18,
        /// <summary>
        /// Week ahead
        /// </summary>
        A31,
        /// <summary>
        /// Month ahead
        /// </summary>
        A32,
        /// <summary>
        /// Year ahead
        /// </summary>
        A33,
        /// <summary>
        /// Synchronisation process
        /// </summary>
        A39,
        /// <summary>
        /// Intraday process
        /// </summary>
        A40,
        /// <summary>
        /// Replacement reserve
        /// </summary>
        A46,
        /// <summary>
        /// Manual frequency restoration reserve
        /// </summary>
        A47,
        /// <summary>
        /// Automatic frequency restoration reserve
        /// </summary>
        A51,
        /// <summary>
        /// Frequency containment reserve
        /// </summary>
        A52,
        /// <summary>
        /// Frequency restoration reserve
        /// </summary>
        A56
    }
}
