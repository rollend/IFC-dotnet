using System;

namespace IFC4
{

	public class STEPUnknownTypeException : Exception
	{
		private string desiredType;

		public override string Message
		{
			get
			{
				return $"A type corresponding to, {desiredType}, cannot be found in IFC-dotnet assembly.";
			}
		}

		public STEPUnknownTypeException(string desiredType)
		{
			this.desiredType = desiredType;
		}
	}

	public class STEPParserException : Exception
	{
		private string parseValue;
		private Type destinationType;
		public override string Message
		{
			get{return $"The specified value, {parseValue}, could not be coerced into the type, {destinationType.Name}";}
		}

		public STEPParserException(Type destinationType, string parseValue)
		{
			this.destinationType = destinationType;
			this.parseValue = parseValue;
		}
	}

	public class STEPParameterMismatchException : Exception
	{
		Type type;
		int providedCount;
		int expectedCount;

		public override string Message
		{
			get
			{
				return $"{type}'s constructor expects {expectedCount} parameters but {providedCount} parameters are provided.";
			}
		}

		public STEPParameterMismatchException(Type type, int providedCount, int expectedCount)
		{
			this.type = type;
			this.providedCount = providedCount;
			this.expectedCount = expectedCount;
		}
	}
}