//
//  PolygonMaterial.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System.IO;
using Warcraft.Core.Interfaces;

namespace Warcraft.WMO.GroupFile.Chunks
{
    /// <summary>
    /// Represents a polygon material.
    /// </summary>
    public class PolygonMaterial : IBinarySerializable
    {
        /// <summary>
        /// Gets or sets the material flags.
        /// </summary>
        public PolygonMaterialFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the material index.
        /// </summary>
        public byte MaterialIndex { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonMaterial"/> class.
        /// </summary>
        /// <param name="inData">The binary data.</param>
        public PolygonMaterial(byte[] inData)
        {
            using var ms = new MemoryStream(inData);
            using var br = new BinaryReader(ms);
            Flags = (PolygonMaterialFlags)br.ReadByte();
            MaterialIndex = br.ReadByte();
        }

        /// <summary>
        /// Gets the serialized size of the instance.
        /// </summary>
        /// <returns>The size.</returns>
        public static int GetSize()
        {
            return 2;
        }

        /// <inheritdoc/>
        public byte[] Serialize()
        {
            using var ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write((byte)Flags);
                bw.Write(MaterialIndex);
            }

            return ms.ToArray();
        }
    }
}
