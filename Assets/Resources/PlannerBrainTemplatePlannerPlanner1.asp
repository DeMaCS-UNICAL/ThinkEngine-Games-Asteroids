%For runtime instantiated GameObject, only the prefab mapping is provided. Use that one substituting the gameobject name accordingly.
 %Sensors.
%playerSensor(player,objectIndex(Index),intPair(x(Value))).
%playerSensor(player,objectIndex(Index),intPair(y(Value))).
%playerSensor(player,objectIndex(Index),player(velocityX(Value))).
%playerSensor(player,objectIndex(Index),player(velocityY(Value))).
%asteroidSensor(asteroid,objectIndex(Index),intPair(x(Value))).
%asteroidSensor(asteroid,objectIndex(Index),intPair(y(Value))).
%boundarySensor012(boundary,objectIndex(Index),intPair(x(Value))).
%boundarySensor012(boundary,objectIndex(Index),intPair(y(Value))).
%boundarySensor01(boundary,objectIndex(Index),intPair(x(Value))).
%boundarySensor01(boundary,objectIndex(Index),intPair(y(Value))).
%boundarySensor0(boundary,objectIndex(Index),intPair(x(Value))).
%boundarySensor0(boundary,objectIndex(Index),intPair(y(Value))).
%boundarySensor(boundary,objectIndex(Index),intPair(x(Value))).
%boundarySensor(boundary,objectIndex(Index),intPair(y(Value))).
% Predicates for Action invokation.
% applyAction(OrderOfExecution,ActionClassName).
% actionArgument(ActionOrder,ArgumentName, ArgumentValue).