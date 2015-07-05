using UnityEngine;
using System.Collections;

public static class EventCore {





	public static class MouseEvents {

		public class MouseEventArgs {
			public float dx = 0.0f;
			public float dy = 0.0f;

			public MouseEventArgs(float dx, float dy) {
				this.dx = dx;
				this.dy = dy;
			}
		}

		public delegate void EventHandlerOnMouseMove(MouseEventArgs mouseEventArgs);
		public static event EventHandlerOnMouseMove _OnMouseMove = null;

		public static void TriggerEvent_OnMouseMove(MouseEventArgs mouseEventArgs) {
			if(_OnMouseMove != null) _OnMouseMove(mouseEventArgs);
		}

	}
}
