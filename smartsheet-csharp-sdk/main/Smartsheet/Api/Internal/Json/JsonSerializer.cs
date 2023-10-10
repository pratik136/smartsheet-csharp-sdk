//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System.Collections.Generic;

namespace Smartsheet.Api.Internal.Json
{

    using Api.Models;
    using System.IO;

    /// <summary>
    /// This interface defines methods to handle JSON serialization/de-serialization.
    /// 
    /// Thread Safety: Implementation of this interface must be thread safe.
    /// </summary>
    public interface JsonSerializer
    {

        /// <summary>
        /// Serialize an object to JSON.
        /// 
        /// Parameters: - object : the object to serialize - outputStream : the output stream to which the JSON will be
        /// written
        /// 
        /// Returns: None
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="object"> the object </param>
        /// <param name="outputStream"> the output stream </param>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        void serialize<T>(T @object, StreamWriter outputStream);

        /// <summary>
        /// De-serialize an object from JSON.
        /// 
        /// Parameters: - objectClass : the class of the object to de-serialize - inputStream : the input stream from which
        /// the JSON will be read
        /// 
        /// Returns: the de-serialized object
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the t </returns>
        /// <exception cref="Newtonsoft.Json.JsonException"> the Json parse exception </exception>
        /// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
        T deserialize<T>(StreamReader inputStream);

        /// <summary>
        /// De-serialize an object from A JSON String.
        /// 
        /// Parameters: - objectClass : the class of the object to de-serialize - string : the input stream from which
        /// the JSON will be stored
        /// 
        /// Returns: the de-serialized object
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="input"> the input string that holds the JSON object </param>
        /// <returns> the t </returns>
        /// <exception cref="Newtonsoft.Json.JsonException"> the Json parse exception </exception>
        /// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
        T deserialize<T>(string input);

        /// <summary>
        /// De-serialize an object list from JSON.
        /// 
        /// Parameters: - objectClass : the class of the object (of the list) to de-serialize - inputStream : the input
        /// stream from which the JSON will be read
        /// 
        /// Returns: the de-serialized list
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the list </returns>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        IList<T> deserializeList<T>(StreamReader inputStream);

        /// <summary>
        /// De-serialize an object to DataWrapper from JSON.
        /// 
        /// Parameters: - objectClass : the class of the object to de-serialize - inputStream : the input stream from which
        /// the JSON will be read
        /// 
        /// Returns: the de-serialized object
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the t </returns>
        /// <exception cref="Newtonsoft.Json.JsonException"> the Json parse exception </exception>
        /// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
        PaginatedResult<T> DeserializeDataWrapper<T>(StreamReader inputStream);

        /// <summary>
        /// De-serialize an object list from JSON to a Map.
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the map </returns>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        IDictionary<string, object> DeserializeMap(StreamReader inputStream);

        /// <summary>
        /// De-serialize a RequestResult&lt;T&gt; object from JSON.
        /// 
        /// Parameters: - objectClass : the class of the object (of the RequestResult) to de-serialize - inputStream : the input
        /// stream from which the JSON will be read
        /// 
        /// Returns: the de-serialized RequestResult
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the RequestResult </returns>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        RequestResult<T> deserializeResult<T>(StreamReader inputStream);

        /// <summary>
        /// De-serialize a RequestResult&lt;List&lt;T&gt;&gt; object from JSON.
        /// 
        /// Parameters: - objectClass : the class of the object (of the RequestResult) to de-serialize - inputStream : the input
        /// stream from which the JSON will be read
        /// 
        /// Returns: the de-serialized RequestResult
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the RequestResult </returns>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        RequestResult<IList<T>> deserializeListResult<T>(StreamReader inputStream);

        /// <summary>
        /// De-serialize a CopyOrMoveRowResult object from JSON.
        /// 
        /// Parameters: 
        ///     - inputStream : the input stream from which the JSON will be read
        /// 
        /// Returns: the de-serialized CopyOrMoveRowResult
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the CopyOrMoveRowResult </returns>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        CopyOrMoveRowResult DeserializeRowResult(StreamReader inputStream);

        /// <summary>
        /// De-serialize to a EventResult (holds pagination info) object from JSON.
        /// 
        /// Parameters:
        ///     - inputStream : the input stream from which the JSON will be read
        /// 
        /// Returns: the de-serialized EventResult
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream </param>
        /// <returns> the EventResult containing a list of Event </returns>
        /// <exception cref="JsonSerializationException"> the JSON serializer exception </exception>
        EventResult DeserializeEventResult(StreamReader inputStream);
    }

}