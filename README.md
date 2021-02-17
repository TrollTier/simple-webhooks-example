# simple-webhooks-example
This is a simple implementation to demonstrate the idea behind webhooks.

You can use the register function in the webhooks controller to register a new endpoint to be called for a specific event.

Currently there is only an event for a created order, but you can extend it if you want.

# Current flow idea
1. Start provider and client
2. Register client endpoint in provider
3. Send new order to providers' order creation endpoint
4. The client should now print new information on the command line