﻿// Copyright 2016 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Apis.Bigquery.v2.Data;
using Xunit;

namespace Google.Bigquery.V2.Tests
{
    public class CreateQueryJobOptionsTest
    {
        [Fact]
        public void PropertiesSetOnRequest()
        {
            var options = new CreateQueryJobOptions
            {
                AllowLargeResults = true,
                CreateDisposition = CreateDisposition.CreateNever,
                DefaultDataset = new DatasetReference { ProjectId = "a", DatasetId = "b" },
                DestinationTable = new TableReference { ProjectId = "a", DatasetId = "b", TableId = "c" },
                FlattenResults = false,
                MaximumBillingTier = 10,
                Priority = QueryPriority.Batch, 
                UseQueryCache = false,
                WriteDisposition = WriteDisposition.WriteIfEmpty
            };

            JobConfigurationQuery query = new JobConfigurationQuery();
            options.ModifyRequest(query);
            Assert.Equal(true, query.AllowLargeResults);
            Assert.Equal("CREATE_NEVER", query.CreateDisposition);
            Assert.Equal("b", query.DefaultDataset.DatasetId);
            Assert.Equal("c", query.DestinationTable.TableId);
            Assert.Equal(false, query.FlattenResults);
            Assert.Equal(10, query.MaximumBillingTier);
            Assert.Equal("BATCH", query.Priority);
            Assert.Equal(false, query.UseQueryCache);
            Assert.Equal("WRITE_EMPTY", query.WriteDisposition);
        }
    }
}