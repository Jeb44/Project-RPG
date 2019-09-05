namespace Game.Combat {
	public enum Element {
		Neutral,
		Fire,
		Water,
		Earth,
		Wind,
		Light,
		Dark
	}

	static class StuffMethods{
		public static Element GetOppositeElement(this Element element){
			switch (element){
				case Element.Earth:
					return Element.Wind;
				case Element.Wind:
					return Element.Earth;
				case Element.Water:
					return Element.Water;
				case Element.Fire:
					return Element.Water;
				default:
					return Element.Neutral;
			}
		}
}
}

