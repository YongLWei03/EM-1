export class Client {
    Name: string;
    Plugin: Plugin;
    Properties: Properties;
    Schedule: Schedule;
}

export class Schedule {
    IsRunContinuously: boolean;
    RunEverySeconds: number;
}

export class Properties {
    IsEnabled: boolean;
    Description: string;
}

export class Runtime {
    LastRun: Date;
    LastLifeSign: Date;
    NextRun: Date;
}

export class Plugin {
    Name: string;
}
