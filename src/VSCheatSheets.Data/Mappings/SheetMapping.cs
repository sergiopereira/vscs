#region Copyright notice
// Copyright (c) 2011, Sergio Pereira, sergiopereira.com
// 
// The author doesn't speak legalese and doesn't want to even hear about it.
// Anyone is free to use this code as they wish as long as they assume total responsibility of such use and any damages caused by it.
// The author doesn't even care if you steal this code and never give proper attribution. 
// 
// THIS CODE WANTS TO BE FREE
#endregion
using System;
using VSCheatSheets.Model;

namespace VSCheatSheets.Data.Mappings {
	public class SheetMapping : EntityMapping<Sheet> {
		
		protected override void MapProperties() {

			Map(x => x.ContentMarkdown).Not.Nullable().Length(Sheet.ContentMaxLength);
			Map(x => x.Name).Not.Nullable().Length(Sheet.NameMaxLength);
			Map(x => x.Description).Nullable().Length(Sheet.DescriptionMaxLength);
			Map(x => x.Permalink).Not.Nullable().Length(Sheet.PermalinkMaxLength);

		}
	}
}