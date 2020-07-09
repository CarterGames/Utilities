using System;
using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/


namespace CarterGames.Utilities
{
    /// <summary>
    /// Serialize types that are not serializable by default.
    /// </summary>
    public static class ExtraSerialize
    {
        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Serializes the inputted sprite (note it will not have a name when serialized).
        /// </summary>
        /// <param name="input">sprite to serialize</param>
        /// <returns>A SerializedSprite object which can be used with normal saving mathods (binrary formatter etc.)</returns>
        public static SerializeSprite SpriteSerialize(Sprite input)
        {
            Texture2D texture = input.texture;
            SerializeSprite sprite = new SerializeSprite(texture.width, texture.height, ImageConversion.EncodeToPNG(texture));
            return sprite;
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deserializes the inputted SerializeSprite object (note it will not have a name when deserialized).
        /// </summary>
        /// <param name="input">SerializeSprite object you want to deserialize</param>
        /// <returns>The deserialized Sprite.</returns>
        public static Sprite SpriteDeSerialize(SerializeSprite input)
        {
            SerializeSprite sprite = input;
            Texture2D texture = new Texture2D(sprite.x, sprite.y);
            ImageConversion.LoadImage(texture, sprite.data);
            return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.one);
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Serializes the inputted Vector3.
        /// </summary>
        /// <param name="input">The Vector3 to serialize</param>
        /// <returns>A SerializeVector3 object which can be used with normal saving mathods (binrary formatter etc.)</returns>
        public static SerializeVector3 Vector3Serialize(Vector3 input)
        {
            return new SerializeVector3(input);
        }


        /// ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deserializes the inputted SerializeVector3 object back into a Vector3 for use.
        /// </summary>
        /// <param name="input">SerializeVector3 object to deserialize</param>
        /// <returns>The deserialized Vector3</returns>
        public static Vector3 Vector3DeSerialize(SerializeVector3 input)
        {
            return new Vector3(input.x, input.y, input.z);
        }
    }


    /// ------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Holds the values required to save/load a Sprite.
    /// </summary>
    [Serializable]
    public class SerializeSprite
    {
        [SerializeField]
        public int x;
        [SerializeField]
        public int y;
        [SerializeField]
        public byte[] data;

        public SerializeSprite() { }

        public SerializeSprite(int inputX, int inputY, byte[] inputData)
        {
            x = inputX;
            y = inputY;
            data = inputData;
        }
    }


    /// ------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Holds the values required to save/load a Vector3.
    /// </summary>
    [Serializable]
    public class SerializeVector3
    {
        [SerializeField]
        public float x;
        [SerializeField]
        public float y;
        [SerializeField]
        public float z;

        public SerializeVector3() { }

        public SerializeVector3(Vector3 input)
        {
            x = input.x;
            y = input.y;
            z = input.z;
        }

        public SerializeVector3(float inputX, float inputY, float inputZ)
        {
            x = inputX;
            y = inputY;
            z = inputZ;
        }
    }
}