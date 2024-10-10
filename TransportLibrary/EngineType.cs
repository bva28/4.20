using System.ComponentModel;

namespace TransportLibrary
{
    /// <summary>
    /// EngineType.
    /// </summary>
    public enum EngineType
    {
        /// <summary>
        /// Бензиновый.
        /// </summary>
        [Description("Бензиновый")]
        Petrol,

        /// <summary>
        /// Дизельный.
        /// </summary>
        [Description("Дизельный")]
        Diesel,

        /// <summary>
        /// Электричество.
        /// </summary>
        [Description("Электрический")]
        Electricity,

        /// <summary>
        /// Газотурбинный.
        /// </summary>
        [Description("Газотурбинный")]
        GasTurbine
    }
}
