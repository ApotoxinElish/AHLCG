using System;
using System.Collections.Generic;

using UnityEngine;

namespace AHLCG
{
    /// <summary>
    /// The modifier of a stat.
    /// </summary>
    public class Modifier
    {
        /// <summary>
        /// The constant value to identify a permanent modifier.
        /// </summary>
        private const int PERMANENT = 0;

        /// <summary>
        /// The value of this modifier.
        /// </summary>
        public int value;

        /// <summary>
        /// The duration of this modifier.
        /// </summary>
        public int duration;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The value of the modifier.</param>
        /// <param name="duration">The duration of the modifier.</param>
        public Modifier(int value, int duration = PERMANENT)
        {
            this.value = value;
            this.duration = duration;
        }

        /// <summary>
        /// Returns true if this modifier is permanent and false otherwise.
        /// </summary>
        /// <returns>True if this modifier is permanent; false otherwise.</returns>
        public bool IsPermanent()
        {
            return duration == PERMANENT;
        }
    }

    public class Stat
    {

    }
}
